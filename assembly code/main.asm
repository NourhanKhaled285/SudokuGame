include irvine32.inc

.data
arrStrSz equ 97
initialArr byte 81 dup(?)

initialArrStr byte arrStrSz dup(?),0

finishedArr byte 81 dup(?)
finishedArrStr byte arrStrSz dup(?),0   ;;;;;;;;;;;;;;;;;;;;;
		 
savedArr byte 81 dup(?)
savedArrStr byte 173 dup(?),0

;--------TIME DATA----------------------
gameTime dword ?
startTime dword ?
;--------BOARD DATA---------------------

colorArr byte 81 dup(?)

boardSize byte 81
enterdCell byte ?
row byte ?
col byte ?
valueFlag byte ?
cellColor byte ?
rFlag byte ?
emptyCellCount byte ?

redCell byte 0
greenCell byte 1
blueCell byte 2
blackCell byte 3

correct byte ?
incorrect byte ?

;-------new file data-------
cantOpenFileMsg byte "Can't open file",0
cantReadFileMsg byte "Can't read file",0  
buffSzSmallMsg byte "Error: Buffer too small for the file",0
;-------new proc data------
lvlFileName byte "diff_?_?.txt",0
solvedLvlFileName byte "diff_?_?_solved.txt",0
BUFFER_SIZE = 5000
savedFile byte "savedBoardFile.txt",0
initialBoardFile byte "diff_1_1.txt",0
finalBoardFile byte "diff_?_?_solved.txt",0
fileHandle handle ?
createFileError BYTE "Cannot create file",0dh,0ah,0
bytesWritten dword ?

.code
;-----------------------------------------------------------------------------------------------
convertStrToArr proc,aStr :ptr byte, sArr :ptr byte          
mov ecx , arrStrSz
;inc ecx ;the arrStr is terminated by '0'
mov esi,aStr
mov edi,sArr

cS2A:
    mov al,[esi]
	sub al,'0'
	mov bl,0ddh
	cmp al,bl    ;cmp char with '\r'
	je skipConversion
	mov bl,0dah  ;cmp char with '\n'
	cmp al,bl
	je skipConversion

	mov [edi],al
	inc edi
	skipConversion:
	inc esi
	
loop cS2A
ret
convertStrToArr endp
;-----------------------------------------------------------------------------------------------

readBoardFromFile proc, fileName:ptr byte, tmpStr: ptr byte,tmpArr:ptr byte ;,eMsg:ptr byte           
                                                          
; Open the file for input.

mov edx , fileName                   ; filename
call OpenInputFile                   ;opens board file
mov fileHandle,eax

; Check for errors.
cmp eax,INVALID_HANDLE_VALUE             ; error opening file?                            
jne fileOkLbl     

;mov esi,offset cantOpenFileMsg
;mov edi,eMsg
;mov ecx ,lengthof cantOpenFileMsg
;rep movsb                        
jmp quit
                                             ; and quit
fileOkLbl:
; Read the file into a tmp arr in string format
mov edx, tmpStr
mov ecx,BUFFER_SIZE
call ReadFromFile

jnc checkBufferSizeLbl ; error reading?

;mov esi,offset cantReadFileMsg
;mov edi,eMsg
;mov ecx ,lengthof cantReadFileMsg
;rep movsb                ; yes: show error message

jmp closeFileLbl

checkBufferSizeLbl:
cmp eax,BUFFER_SIZE      ; buffer large enough?
jb bufferSizeOkLbl           ; yes

;mov esi,offset buffSzSmallMsg
;mov edi,eMsg
;mov ecx ,lengthof buffSzSmallMsg
;rep movsb                ; yes: show error message
jmp quit        ; and quit

bufferSizeOkLbl:
mov edx,tmpStr
mov byte ptr[edx+eax],0 ; insert null terminator

closeFileLbl:
mov eax,fileHandle
call CloseFile
   
invoke convertStrToArr , tmpStr , tmpArr
quit:
ret
readBoardFromFile endp
;-----------------------------------------------------------------------------------------------
displayResultBoard proc ,fArr:ptr byte, cArr:ptr byte
mov esi,offset savedArr
mov edi,offset finishedArr
mov edx,offset colorArr
movzx ecx ,boardSize

L2:
   mov al,byte ptr[esi]
   cmp al,[edi]
   je solved
   mov al,blueCell
   mov [edx],al
   jmp skipppp

   solved:
   mov al,greenCell
   mov [edx],al
  
   skipppp:
   inc edx 
   inc esi
   inc edi
loop L2

mov esi,offset initialArr
mov edi,offset finishedArr
mov edx,offset colorArr
movzx ecx ,boardSize

L3:
   mov al,byte ptr[esi]
   cmp al,[edi]
   je initial   
   ;mov al,blueCell
   ;mov [edx],al
   jmp skippppp

   initial:
   mov al,blackCell
   mov [edx],al
   
   skippppp:
   inc edx 
   inc esi
   inc edi
loop L3

mov esi,offset colorArr
mov edi,offset finishedArr

movzx ecx ,boardSize
L4:
   mov al,byte ptr[esi]
   mov ebx,cArr
   mov [ebx],al

   mov al,byte ptr[edi]
   mov edx ,fArr
   mov [edx],al

   inc esi
   inc edi
   inc cArr
   inc fArr
loop L4
   ret
displayResultBoard endp

;-----------------------------------------------------------------------------------------------
readInitialArr proc, iArr:ptr byte, cArr:ptr byte

mov edi, offset colorArr           ;fill color array with zeroes before start
mov ecx, lengthof colorArr
mov al, 0 ;                    save number you want to initialize with in the al
rep stosb

mov esi ,offset initialArr
mov edi ,iArr
mov eax ,offset colorArr
mov ebx ,cArr


movzx ecx,boardSize

l5:
   mov dl,[esi]
   cmp dl,0
   je skipBlackColor
   mov dl,blackCell
   mov [eax],dl
   mov [ebx],dl
   skipBlackColor:
   movsb 
   inc eax
   inc ebx

loop l5


;fill savedArr wuth initial board at game start
mov esi ,offset initialArr
mov edi ,offset savedArr
movzx ecx,boardSize
rep movsb 
;mov eax,iArr
;mov edi ,zeroFlagArr
;mov esi,offset initialArr
;movzx ecx,boardSize
;l5:
 ;  mov bl,byte ptr[esi]
  ; mov [eax], bl
  ;
   ;mov dl,[edi]
   ;cmp bl,0
   ;je zeroFlag
   ;mov bl,1
   ;jmp skipppppp
   ;zeroFlag:
   ;mov bl,0

;   skipppppp:
 ;  inc eax
  ; inc esi
   ;inc edi
;loop l5

ret
readInitialArr endp
;-----------------------------------------------------------------------------------------------
calculateGameTime proc

INVOKE GetTickCount ; get new tick count
cmp eax,startTime ; lower than starting one?
jb error ; it wrapped around

sub eax,startTime ; get elapsed milliseconds
mov edx,0
mov ebx,60000
div ebx
mov gameTime ,eax

error:
ret
calculateGameTime endp
;-----------------------------------------------------------------------------------------------
chooseLevel proc ,diff :byte , iArr:ptr byte, icArr:ptr byte , fArr:ptr byte, fcArr:ptr byte
;, msg: ptr byte

mov ebx,offset lvlFileName 
mov edx,offset solvedLvlFileName

mov al,diff
add al,'0'
mov [ebx+5],al
mov [edx+5],al

randomLbl:
mov eax,3      
call randomrange      ;0---2
inc eax               ;1---3

add al,'0'
mov [ebx+7],al
mov [edx+7],al

mov ebx,offset lvlFileName 
mov eax,offset initialArrStr
mov edx,offset initialArr
invoke readBoardFromFile ,ebx, eax, edx;, msg
 
mov ebx,offset solvedLvlFileName
mov eax,offset finishedArrStr
mov edx,offset finishedArr
invoke readBoardFromFile ,ebx, eax, edx;, msg 

mov eax,iArr
mov ebx,icArr
invoke readInitialArr ,eax , ebx

;mov eax,fArr
;mov ebx,fcArr
;invoke displayResultBoard ,eax,ebx

INVOKE GetTickCount ; get starting tick count after displaying board
mov startTime,eax 

ret 
chooseLevel endp

;------------------------------------------------------------------------------------------------
StorePlayerCell proc, val:byte ,r:byte ,co:byte
mov al,val
mov enterdCell,al
mov al,r
mov row,al
mov al,co
mov col,al
ret
StorePlayerCell endp
;------------------------------------------------------------------------------------------------
;flag decides if we compare enetered value with board later
;but now indicates if enteredcell is within our range
;-----------------------------------------------------------------------------------------------
IsWithinRange proc , rangeFlag:ptr byte , cellVal :ptr byte

mov ebx,cellVal
mov edi,[ebx]
cmp  edi, 1
jb error
cmp edi , 9 
ja error
jmp skippp 
error: 
   mov ecx,rangeFlag
   mov byte ptr[ecx],0
   mov edi,0
   mov [ebx],edi
   ret 
skippp:
   
   mov ecx,rangeFlag
   mov byte ptr[ecx] ,1

   ret
IsWithinRange endp



;------------------------------------------------------------------------------------------------
updateScore proc flag:byte 
      cmp flag,1
	  jne wrong

	  right:
	  mov al ,greenCell
	  mov cellColor ,al
	  inc correct
	  dec emptyCellCount
	  jmp skip

	  wrong: 
	      mov enterdCell,0
	      mov al ,redCell
	      mov cellColor ,al
		  inc incorrect

      skip:
	  ret

updateScore endp
;---------------------------------------------------------------------------------------------

IsCorrect proc,  cColor: ptr byte,eCell:ptr byte

mov al,row        ;
mov bl,9
mul bl
mov cl,col

add al,cl
movzx esi,al

mov dl , finishedArr[esi]
cmp enterdCell,dl
jne wrongAnswer
mov valueFlag,1
mov savedArr[esi],dl
jmp skipWrongAnswer

wrongAnswer:
mov valueFlag,0

skipWrongAnswer:
invoke updateScore , valueFlag

mov al,cellColor
mov edx , cColor 
mov [edx],al

mov al,enterdCell
mov edx , eCell
mov [edx],al
ret

IsCorrect endp 

;-----------------------------------------------------------------------------------------------
countEmptyCells proc
mov esi,offset initialArr
movzx ecx ,boardSize

L1:
   mov edi , 0
   cmp [esi],edi
   jne skip
   inc emptyCellCount
   skip:
   inc esi
loop L1
countEmptyCells endp
;-----------------------------------------------------------------------------------------------
readSavedArrFromAssem proc, sArr:ptr byte, cArr:ptr byte

mov edx,OFFSET savedFile
mov esi,offset savedArrStr
mov edi,offset savedArr

invoke readBoardFromFile ,edx , esi, edi

mov esi,offset savedArr
mov edi ,sArr
movzx ecx,boardSize
rep movsd

mov esi,offset colorArr
mov edi ,cArr
movzx ecx,boardSize
rep movsd

ret

readSavedArrFromAssem endp
;------------------------------------------------------------------------------------------------
convertSavedDataToStr proc  ;invoked when player press save & exit


;invoke calculateGameTime    ;calculate game time

;movzx ecx ,boardSize
;mov esi,offset savedArr
;mov edi,offset savedArrStr
;cSA2S:             ;convert saved arr to string
;    mov al,[esi];
;	add al,'0'
;	mov [edi],al
;	inc esi
;	inc edi
;loop cSA2S

;movzx ecx ,boardSize
;mov esi,offset colorArr
;;mov edi,offset savedArrStr
;cCA2S:             ;convert color arr to string
 ;   mov al,[esi]
;	add al,'0'
;	mov [edi],al
;	inc esi
;	inc edi
;loop cCA2S


;mov ecx,2
;mov eax,offset correct
;L1:
;add byte ptr[eax],'0'
;mov byte ptr[edi],al

;mov al,incorrect
;add al,'0'
;mov byte ptr[edi],al

;mov eax,gameTime
;add eax,'0'
;mov [edi],eax

movzx ecx ,boardSize
mov esi,offset savedArr
mov edi,offset savedArrStr
cA2S:
   mov al,[esi]
	add al,'0'
	mov [edi],al
	inc esi
	inc edi
loop cA2S



ret

convertSavedDataToStr endp

;------------------------------------------------------------------------------------------------
writeSavedBoardInFile proc, errorFlag: ptr byte

invoke convertSavedDataToStr 

; Create a new text file.
mov edx,OFFSET savedFile
call CreateOutputFile
mov fileHandle,eax

;Check for errors.
cmp eax, INVALID_HANDLE_VALUE ; error found? 
jne file_ok ; no: skip
;mov edx,errorFlag ; display error 
;mov byte ptr[edx],1
jmp quit

file_ok:
; Write the buffer to the output file.
mov eax,fileHandle 
mov edx,OFFSET savedArrStr 
mov ecx, lengthof savedArrStr
call WriteToFile
mov bytesWritten,eax ; save return value 
call CloseFile 

quit:
ret 
writeSavedBoardInFile endp
;-----------------------------------------------------------------------------------------------
displayScore proc ,cor: byte,inCor: byte
mov al,correct
mov cor,al

mov al,incorrect
mov inCor,al

ret
displayScore endp


;------------------------------------------------------------------------------------------------
;DllMain is required for any DLL
DllMain PROC hInstance:DWORD, fdwReason:DWORD, lpReserved:DWORD 

mov eax, 1		; Return true to caller. 
ret 				
DllMain ENDP

END DllMain
