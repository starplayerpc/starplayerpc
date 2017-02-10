function probe()
    return string.match(vlc.path, "%.spp$")
end

function parse()
    playlist = {}

	playlist_item = {}
	playlist_item.path = "file:///C:/Program Files (x86)/StarPlayerPC/sppc.bin"
	playlist_item.meta = { ["Playback mode"] = "repeat" }
	table.insert( playlist, playlist_item )
	playlist_item = {}
	playlist_item.path = "file:///C:/Program Files (x86)/StarPlayerPC/sppcb.bin"
	playlist_item.meta = { ["Playback mode"] = "repeat" }
	table.insert( playlist, playlist_item )	
	
    while true do
        playlist_item = {}
        line = vlc.readline()
        if line == nil then
            break
        end

        -- parse playlist line into two tokens splitting on comma
        values = {}
        i=0
        for word in string.gmatch(line, '([^|]+)') do
            values[i]=word
            i=i+1
        end

        playlist_item.path = values[0]
        playback_mode = values[1]

        playlist_item.options = { "fullscreen" }
		
		playlist_item.meta = { ["Playback mode"] = playback_mode }
		
        -- add the item to the playlist
        table.insert( playlist, playlist_item )
    end

	playlist_item = {}
	playlist_item.path = "file:///C:/Program Files (x86)/StarPlayerPC/sppcb.bin"
	playlist_item.meta = { ["Playback mode"] = "repeat" }
	table.insert( playlist, playlist_item )	
	
    return playlist
end
