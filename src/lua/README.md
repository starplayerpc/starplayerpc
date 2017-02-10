The first character of the filename for the extension is '!'. This character is very late in the ASCII character table, so this should have the effect of making this extension the last extension in the list of extensions imported by VLC.

This is important because we have to manually activate the extention each time VLC loads. To achieve this we current use sendkeys and send a key sequence to VLC that results in the final extension on the list being activated.

The first character of the filename of the playlist script is '~'. This character is very early in the ASCII character table, so this should have the effect of making this script the first of the playlist scripts used by VLC when attempting to load playlist files.

