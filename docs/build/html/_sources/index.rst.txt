.. reVIEW documentation master file, created by
   sphinx-quickstart on Tue Dec 27 10:10:42 2016.
   You can adapt this file completely to your liking, but it should at least
   contain the root `toctree` directive.

.. toctree::
   :maxdepth: 2
   :caption: Contents:

   development
   tidyup
   playlisteditor


Requirements
============

* A capability for playing a series of video clips in a playlist whilst specifying which clips should loop/repeat forever (until the user selects forward or back) and which clips should play once before automatically advancing to the next clip.


Possible future extensions
==========================

* Repeat N times
* Optionally specify start and stop (A-B) points in clip

Solution
========

* Extend the popular VLC open source video play to accept playlists with loop information
* VLC is licensed under GPV v2 or above, this solution will use the compatible LGPL v2+ licence

Approach
========

1. Create a playlist script to read and process a text file as a playlist. The extra information on whether to `repeat` or `continue` each track should be stored in the playlist track metadata.

2. Create an extension that toggles the playlist mode depending on the metadata for each track.

3. Find `command line options <https://wiki.videolan.org/VLC_command-line_help/>`_ to start VLC full screen, with extension enabled and running the required playlist. See `--play-and-exit`, but provide a couple of black screen looping videos (or still images) so that the player does not return to the machine desktop during a live broadcast. Consider special key to exit (disabling usual prev/next to prevent accidental exit during live broadcast)?

4. Create a playlist creater to allow users to easily select video clips and repeat behaviour. Consider implementing as a Lua interface script.

5. Further customisation, see: supress_video_title_filename.png

