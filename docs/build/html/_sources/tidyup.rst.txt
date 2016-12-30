Simplifying the process for users
=================================

If extensions could be loaded automatically on load then I would be home and dry with something like:

 vlc.exe --fullscreen --qt-display-mode=2 playlist.txt
 
This would start the play with minimal interface and in fullscreen.  The required behaviours would then kick in once the extension processed the event triggers as the tracks changed.

However, extensions cannot be started automatically on load.

* http://stackoverflow.com/questions/29047899/run-vlc-extension-from-command-line
* http://stackoverflow.com/questions/15795385/how-can-i-write-a-plugin-for-vlc-that-responds-to-play-pause-and-stop-events/34250783#comment56257933_34250783 (continued in discussion - see comments)

See the corresponding `VLC ticket <https://trac.videolan.org/vlc/ticket/3883>`_.

1. AutoIt
---------
Scrapped because virus checkers report that it is a virus 

2. Write an entire custom app using LibVLC
------------------------------------------
This would take a long time and carries a lot of risks

3. Create a Lua interface 
-------------------------
Replace the main VLC interface at load time with a custom interface, put the starting of the custom extension in a prominent place (not sure an extension can be started from an interface - just like cannot launch the File Open dialog)

4. Get the capability added to VLC
----------------------------------
This is the best solution - it solves the problem for everyone. For me it allows:

Double click playlist, associate with VLC (or a wrapper that does --fullscreen, minimal interface --qt-display-mode=2, --play-and-exit) with the playlist file extension.

Another option to quit VLC at end of playlist is to add `quit` to the playlist: `vlc://quit`