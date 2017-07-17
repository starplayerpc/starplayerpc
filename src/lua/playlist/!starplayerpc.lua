--[[
StarPlayerPC VLC Lua Playlist Script
https://github.com/starplayerpc/starplayerpc
Copyright 2017

Authors: Ian Edwards
Version: 1.02

-- Process sppc playlists of the form:
--   file_path_uri|start_time|stop_time|repeat|
-- The final pipe symbol is required to match
-- our string.gmatch regular expression

--]]
function probe()
    return string.match(vlc.path, "%.sppc$")
end

function parse()
    playlist = {}

    playlist_item = {}
    playlist_item.path = "file:///C:/Program%20Files/StarPlayerPC/sppmain.png"
    playlist_item.meta = { ["Playback mode"] = "repeat" }
    table.insert( playlist, playlist_item )
    playlist_item = {}
    playlist_item.path = "file:///C:/Program%20Files/StarPlayerPC/sppblck.png"
    playlist_item.meta = { ["Playback mode"] = "repeat" }
    table.insert( playlist, playlist_item )

    while true do
        playlist_item = {}
        line = vlc.readline()
        if line == nil then
            break
        end

        -- parse playlist line into tokens splitting on pipe symbol
        -- gmatch matches the 'words' not the separator (e.g. [not |])
        values = {}
        i=0
        for word in string.gmatch(line, '([^|]*)|') do
            values[i]=word
            i=i+1
        end

        playlist_item.path = values[0]
        playlist_item.meta = { ["Playback mode"] = tostring(values[3]) }

        playlist_item.options = { "fullscreen" }
        if values[1] ~= "" then
            table.insert( playlist_item.options, "start-time="..tostring(values[1]))
        end
        if values[2] ~= "" then
            table.insert( playlist_item.options, "stop-time="..tostring(values[2]))
        end

        -- add the item to the playlist
        table.insert( playlist, playlist_item )
    end

    playlist_item = {}
    playlist_item.path = "file:///C:/Program%20Files/StarPlayerPC/sppblck.png"
    playlist_item.meta = { ["Playback mode"] = "repeat" }
    table.insert( playlist, playlist_item )

    return playlist
end
