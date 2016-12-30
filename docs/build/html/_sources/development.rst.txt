reVIEW documentation
====================

A LUA extension to give users a repeat-by-track capability in VLC playlists.


Related solutions
=================

See all `extensions <https://addons.videolan.org/browse/cat/323/>`._

`VLC Song Tracker <https://addons.videolan.org/p/1154018/>`_ is very promising, at the beginning of each track it records to file the date and time the song was played. This is exactly the point we need to control looping.

`Song Teacher <https://addons.videolan.org/p/1154095/>`_ is a complicated extension that loads a playlist and then reorders it based on how well you don't know the songs. Interaction is via a GUI.


Developing with VLC
===================

Tools > Messages - increase Verbosity to 2 (debug) and view messages in the Messages window. In older versions of VLC, messages were written to `vlc-log.txt`.

API
---
See the main VLC readme for working with LUA: `README.txt`_.


* `playlist.repeat_( [status] )`: Toggle item repeat or set to specified value.

* `video.fullscreen( [status] )`:

 * toggle fullscreen if no arguments are given
 * switch to fullscreen 1st argument is true
 * disable fullscreen if 1st argument is false


Similar capabilities
--------------------
See `Addons <https://addons.videolan.org>`_ for extensions with similar capabilities. e.g.:

* `Time <https://addons.videolan.org/p/1154032/>`_ - displays run time on the screen during playback (we also want to take actions during playback). This extension also has a UI.


Retired
=======

* Extend (3) to provide a Lua interface to select the playlist to run

* Consider using `libVLC <https://wiki.videolan.org/LibVLC>`_ and building a custom application using `Qt <https://github.com/vlc-qt/vlc-qt>`_. See `controlling playback options <http://stackoverflow.com/questions/39333563/building-a-playlist-to-control-playback-options-for-each-media-file-individually>`_


References
==========

* The main VLC readme for working with LUA: `README.txt`_.
* `Advanced use of VLC <https://wiki.videolan.org/Documentation:Advanced_Use_of_VLC/#Playlist_options>`_
* Lua 5.1 `Reference manual <http://www.lua.org/manual/5.1/>`_
* Forum advice on `getting started <https://forum.videolan.org/viewtopic.php?t=98644>`_
* Blogs on extending VLC with Lua: `Coderholic <http://www.coderholic.com/extending-vlc-with-lua/>`_, `Scientific Swede <http://scientificswede.blogspot.co.uk/2012/05/extending-vlc-with-lua.html>`_


.. _README.txt: https://www.videolan.org/developers/vlc/share/lua/README.txt
