--[[
VLC Track Repeat
Copyright 2016

Authors: Ian Edwards

--]]

function descriptor()
  return {
    title = "VLC Track Repeat 0.1",
    version = "0.1",
    author = "isedwards",
    url = "https://github.com/cubeview/reVIEW",
    shortdesc = "VLC Track Repeat",
    description = "",
    capabilities = { "input-listener" }
  }
end

function activate()
  vlc.msg.dbg("[VLC Track Repeat] Activate")
  update_playback_mode()
end

function deactivate()
  vlc.msg.dbg("[VLC Track Repeat] Deactivate")
end

-- Close Trigger
function close()
  vlc.msg.dbg("[VLC Track Repeat] Close")
end

-- Triggers
function input_changed()
  vlc.msg.dbg("[VLC Track Repeat] Input Changed")
  update_playback_mode()
end

function meta_changed()
  -- Meta changes through track playback, therefore do nothing
end

function update_playback_mode()
  -- VLC lua error in file ../../extras/package/win32/../../../modules/lua/libs/video.c line 51 (function vlclua_fullscreen)
  -- previous error said 'string expected' when tried argument `true`
  -- vlc.video.fullscreen("fullscreen")
  vlc.msg.dbg("[VLC Track Repeat] Update playback mode running")
  if vlc.input.is_playing() then
	vlc.msg.dbg("[VLC Track Repeat] Input is playing")

    local item = vlc.item or vlc.input.item()
    if item then
      local meta = item:metas()
      --Check Meta tags
      if meta then
        local playback_mode = meta["Playback mode"]
        if playback_mode == nil then
          playback_mode = false
        elseif string.lower(mode) == "repeat" then
		  playback_mode = true
		else
		  playback_mode = false
		end
				
		-- 'repeat_' (expects string, but does not respond to "repeat"/"repeat_one") therefore toggle instead.
		local player_mode = vlc.playlist.repeat_()
		
		if player_mode and not playback_mode then
			vlc.msg.dbg("[VLC Track Repeat] "..item:uri()..": continue")
			vlc.playlist.repeat_()
		elseif not player_mode and playback_mode then
			vlc.msg.dbg("[VLC Track Repeat] "..item:uri()..": repeat")
			vlc.playlist.repeat_()
		end
		
        return true
      end
    end
  end
end
