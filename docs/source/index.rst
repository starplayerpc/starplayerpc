.. reVIEW documentation master file, created by
   sphinx-quickstart on Tue Dec 27 10:10:42 2016.
   You can adapt this file completely to your liking, but it should at least
   contain the root `toctree` directive.

reVIEW documentation
====================

A LUA extension to give users a repeat-by-track capability in VLC playlists.

.. toctree::
   :maxdepth: 2
   :caption: Contents:


Requirements
============

* A capability for playing a series of video clips in a playlist whilst specifying which clips should loop/repeat forever (until the user selects forward or back) and which clips should play once before automatically advancing to the next clip.

Solution
========

* Extend the popular VLC open source video play to accept playlists with loop information
* VLC is licenced under GPV v2 or above, so the solution will share this licence

Approach
========

1. Start with a playlist script to read and process a text file as a playlist. The extra information of which clips to loop will be ignored
2. Create an extension that reads the playlist as a playlist and also reads tnd handles the additional looping information


References
==========

The main VLC readme for working with LUA: `README.txt`_.



Indices and tables
==================

* :ref:`genindex`
* :ref:`modindex`
* :ref:`search`


.. _README.txt: https://www.videolan.org/developers/vlc/share/lua/README.txt
