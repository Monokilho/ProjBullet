IsDefault=true;
Name="Default";

function checkProp(musicinfo)
return true;
end

function Initialize(luainit,musicinfo)

maxPitch = musicinfo:getMaxPitch()

luainit:newbullet()
luainit:setForce(0.0,-1.7)
luainit:storeBullet()
end

function Fire(luafire,musicinfo)

	local from = {["r"] = 0.0, ["g"] = 0.0, ["b"] = 1.0}
	local to = {["r"] = 0.0, ["g"] = 0.0, ["b"] = 1.0}
	dualChromaByPitch(from,to,luafire,musicinfo)

end

function dualChromaByPitch(from, to, luafire, musicinfo)

	local index = luafire:getIndex()
	local pitch = musicinfo:getValueAt(index)
	
	local midPitch = maxPitch/2
	local colorRGB = 1 - (((1/midPitch)* pitch)/2)
	
	if ( (pitch >= 0) and (pitch < midPitch)) then
		luafire:setBulletColor(from["r"]*colorRGB,from["g"]*colorRGB,from["b"]*colorRGB)
	else
		luafire:setBulletColor(to["r"]*colorRGB,to["g"]*colorRGB, to["b"]*colorRGB)		
	end
	
end