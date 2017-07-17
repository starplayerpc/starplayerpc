--[[
StarPlayerPC VLC Lua Extension
https://github.com/starplayerpc/starplayerpc
Copyright 2017

Authors: Ian Edwards
Version: 1.02

--]]
function descriptor()
  return {
    title = "StarPlayerPC",
    version = "1.02",
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

  vlc.msg.dbg("[StarPlayerPC] set_repeat: " .. tostring(repeat_track) .. "(currently: " .. tostring(player_mode) .. ")")
  
  if player_mode and not repeat_track then
    -- if player_mode is currently true and repeat_track is false then toggle to false
    -- vlc.msg.dbg("[StarPlayerPC] "..item:uri()..": continue")  -- no access to item here
    vlc.playlist.repeat_()
    vlc.msg.dbg("[StarPlayerPC] set_repeat exit: repeat track should now be false")
  
  elseif not player_mode and repeat_track then
    -- if player_mode is currently false and repeat_track is true then toggle to true
    -- vlc.msg.dbg("[StarPlayerPC] "..item:uri()..": repeat")  -- no access to item here
    vlc.playlist.repeat_()
    vlc.msg.dbg("[StarPlayerPC] set_repeat exit: repeat track should now be true")
  end
  
end

function update_playback_mode()
  -- VLC lua error in file ../../extras/package/win32/../../../modules/lua/libs/video.c line 51 (function vlclua_fullscreen)
  -- previous error said 'string expected' when tried argument `true`
  -- vlc.video.fullscreen("fullscreen")
  vlc.msg.dbg("[StarPlayerPC] update_playback_mode running")
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
