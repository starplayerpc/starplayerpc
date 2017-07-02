--[[
StarPlayerPC VLC Lua Extension
https://github.com/starplayerpc/starplayerpc
Copyright 2017

Authors: Ian Edwards

--]]
function descriptor()
  return {
    title = "StarPlayerPC 1.0",
    version = "1.0",
    author = "isedwards",
    url = "https://github.com/starplayerpc/starplayerpc",
    shortdesc = "StarPlayerPC",
    description = "",
    capabilities = { "input-listener" }
  }
end

function activate()
  vlc.msg.dbg("[StarPlayerPC] Activate")
  set_repeat("repeat")
  update_playback_mode()
end

function deactivate()
  vlc.msg.dbg("[StarPlayerPC] Deactivate")
end

-- Custom functions
function set_repeat(repeat_track)
  if repeat_track == nil then
    repeat_track = false
  elseif string.lower(repeat_track) == "repeat" then
    repeat_track = true
  else
    repeat_track = false
  end

  -- 'repeat_' (expects string, but does not respond to "repeat"/"repeat_one") therefore we'll toggle instead
  local player_mode = vlc.playlist.repeat_()

  if player_mode and not repeat_track then
    vlc.msg.dbg("[StarPlayerPC] "..item:uri()..": continue")
    vlc.playlist.repeat_()
  elseif not player_mode and repeat_track then
    vlc.msg.dbg("[StarPlayerPC] "..item:uri()..": repeat")
    vlc.playlist.repeat_()
  end
end

function update_playback_mode()
  -- VLC lua error in file ../../extras/package/win32/../../../modules/lua/libs/video.c line 51 (function vlclua_fullscreen)
  -- previous error said 'string expected' when tried argument `true`
  -- vlc.video.fullscreen("fullscreen")
  vlc.msg.dbg("[StarPlayerPC] Update playback mode running")
  if vlc.input.is_playing() then
    vlc.msg.dbg("[StarPlayerPC] Input is playing")

    local item = vlc.item or vlc.input.item()

    if item then
      local meta = item:metas()
      --Check Meta tags
      if meta then
        set_repeat(meta["Playback mode"])
        return true
      end
    end
  end
end

-- Triggers
function close()
  vlc.msg.dbg("[StarPlayerPC] Close")
end

function input_changed()
  vlc.msg.dbg("[StarPlayerPC] Input Changed")
  update_playback_mode()
end

function playing_changed()
  vlc.msg.dbg("[StarPlayerPC] Playing Changed")
  vlc.msg.dbg("--->" .. vlc.playlist.status())
end

function meta_changed()
  -- Meta changes through track playback, therefore do nothing
end
