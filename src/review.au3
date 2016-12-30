
run("C:\Program Files (x86)\VideoLAN\VLC\vlc.exe")
WinWaitActive("VLC media player")

WinMenuSelectItem ("VLC media player", "View", "VLC Track Repeat")

;~ WinClose("VLC media player")  #CE