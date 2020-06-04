@echo off

::		 *	-h:         Hide software window
::       *  -s "":      String StageParam File to edit
::       *  -sp_fr x:   Stage_param From...
::       *              (0: Arcade; 1: Mobile)
::       *  -sp_to x:   Stage_param To...
::       *              (0: GC4EX; 1: GC2; 2: Switch)
::       *  -i_bgm "":  BGM audio file
::       *  -i_shot "": SHOT audio file to merge or not
::       *  -i_data "": Folder that contain data files
::       *  -n_data "": Name to gameplay data (ex: XXXX is the name in ac_XXXX_easy_ext.dat)
::       *  -g x:       Genre of the song 
::       *              (1: Anime/pop; 2: VOCALOID; 3: MusicGames; 
::       *              4: Game Music; 5: Misc; 6: Original; 7: Touhou)
::       *  -o "":      Output folder
::       *  -nac:       No Audio Converter  
::       *  -ndc:       No Data Converter
::       *  -convert x: Convert mode 
::       *              (0: files only; 1: Convert & Update stage_param)
::

set "convert=1"
set "stage_param=%cd%\test\stage_param.dat"
set "sp_fr=0"
set "sp_to=2"
set "song_folder=C:\Users\cyberkevin\source\repos\Groove Coaster Converter GUI\Groove Coaster Converter\bin\Debug\test\song\invisible"
set "BGM_folder=C:\Users\cyberkevin\source\repos\Groove Coaster Converter GUI\Groove Coaster Converter\bin\Debug\test\song\invisible\sound"
set "output=%cd%\test\out"
set "AudioFormat=.wav"
set "BGM_prefix=_BGM"
set "SHOT_prefix=_SHOT"


echo Converting Arcade to Switch.
:: Examples:
::
::
set "title=7days"
set "BGM=bgm_b-363_7days"
set "SHOT=-i_shot "%BGM_folder%\%BGM%%SHOT_prefix%%AudioFormat%""
set "genre=1"
call:Converting

set "title=invisible"
set "BGM=bgm_b-773_invisible"
set "SHOT="
set "genre=2"
call:Converting


echo Conversion Done
pause
EXIT

:Converting
echo Converting %title%...
START /MIN /W "" "Groove Coaster Converter.exe" -convert %convert% -h -s "%stage_param%" -sp_fr %sp_fr% -sp_to %sp_to% -i_bgm "%BGM_folder%\%BGM%%BGM_prefix%%AudioFormat%" -i_data "%song_folder%" -n_data "%title%" -g %genre% -o "%output%" %SHOT%
::START /W "" "Groove Coaster Converter.exe" -s "%stage_param%" -sp_fr %sp_fr% -sp_to %sp_to% -i_bgm "%BGM_folder%\%BGM%%BGM_prefix%%AudioFormat%" -i_data "%song_folder%" -n_data "%title%" -g %genre% -o "%output%" %SHOT%
EXIT /b