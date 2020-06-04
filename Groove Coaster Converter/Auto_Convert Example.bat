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

set "stage_param=%cd%\test\stage_param.dat"
set "song_folder=%cd%\test\song\"
set "output=%cd%\test\out"

:: Examples:
::
::
set "title=invisible"
echo Converting %title%...
::START /W "" "Groove Coaster Converter.exe" -convert 1 -h -s "%stage_param%" -sp_fr 0 -sp_to 2 -i_bgm "%song_folder%%title%\sound\bgm_b-773_invisible_BGM.wav" -i_data "%song_folder%%title%" -g 2 -o "%output%"

set "title=invisible"
echo Converting %title%...
::START /W "" "Groove Coaster Converter.exe" -convert 1 -h -s "%stage_param%" -sp_fr 0 -sp_to 2 -i_bgm "%song_folder%%title%\sound\bgm_b-773_invisible_BGM.wav" -i_data "%song_folder%%title%" -g 2 -o "%output%"

echo Conversion Done
pause