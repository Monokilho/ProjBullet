IsDefault=false;
Name="Pattern 7";

function checkProp(musicinfo)
return true;
end

function Initialize(luainit,musicinfo)

maxPitch = musicinfo:getMaxPitch()
local pos = luainit:getOriginPosition()

BulletCone(18, -1.7, 0.2, luainit)

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

-- Several bullets aligned horizontal, shooting downwards
-- bulletsNum: The number of bullets
-- bulletDistance: The distance between each line of bullet ( advised a number from 10.0 (Very small distance)
--                 to 100.0 (Very large distance, max distance for 8 bullets line) )
-- bulletsForce: The force the bullet travels downwards (advised number from -1.2 (very slow) to -2.2 (very fast))
-- pos: Vector of x and y position in the map
function BulletLine (bulletsNum, bulletDistance, bulletsForce, pos, luainit)

local posX = pos[0] - (bulletDistance * (bulletsNum/2))

	for i=1,bulletsNum,1 do

	luainit:newbullet()
	luainit:setBulletPosition(posX, pos[1])
	luainit:setForce(0.0,bulletsForce)
	luainit:storeBullet()

	posX = posX + bulletDistance

	end

end


-- A sphere like pattern
-- bulletsNum: The number of bullets to shoot in 360 degree
-- bulletForce: How fast the bullets go (advised a number from 1.0(Slow) to 2.0 (Very Fast) )
function SpherePattern(bulletsNum, bulletForce, luainit)

local bulletsPerQuad = bulletsNum/4
local distancePerQuad = (4.0/bulletsNum)*bulletForce

local x = 0.0
local y = -1.0 * bulletForce

	for i=1,bulletsPerQuad,1 do
	
		luainit:newbullet()
		luainit:setForce(x,y)
		luainit:storeBullet()
		
		x = x - distancePerQuad
		y = y + distancePerQuad
		
	end
	
	for i=1,bulletsPerQuad,1 do
	
		luainit:newbullet()
		luainit:setForce(x,y)
		luainit:storeBullet()
		
		x = x + distancePerQuad
		y = y + distancePerQuad
		
	end
	
	for i=1,bulletsPerQuad,1 do
	
		luainit:newbullet()
		luainit:setForce(x,y)
		luainit:storeBullet()
	
		x = x + distancePerQuad
		y = y - distancePerQuad
		
	end
	
	for i=1,bulletsPerQuad,1 do
	
		luainit:newbullet()
		luainit:setForce(x,y)	
		luainit:storeBullet()
		
		x = x - distancePerQuad
		y = y - distancePerQuad
		
	end

end

-- A sphere like pattern with double line of shots
-- bulletsNum: The number of bullets to shoot in 360 degree
-- bulletForce: How fast the bullets go (advised a number from 1.0(Slow) to 2.0 (Very Fast) )
-- bulletDistance: Distance between the bullets on the double line ( works a little reversed, 
--                 being 1.0 (overlaps the next line, so it's like the normal sphere pattern) and 5.0 (Very closed double line) )
--                 The bigger the number the smaller is the distance between the double line
--                 Do not use numbers less than 1.0!!
function DoubleLineSpherePattern(bulletsNum, bulletForce, bulletDistance, luainit)

local bulletsPerQuad = bulletsNum/4
local distancePerQuad = (4.0/bulletsNum)*bulletForce

local x = 0.0
local y = -1.0 * bulletForce

	for i=1,bulletsPerQuad,1 do
	
		luainit:newbullet()
		luainit:setForce(x,y)
		luainit:storeBullet()
		
		luainit:newbullet()
		luainit:setForce(x-(distancePerQuad/bulletDistance),y+(distancePerQuad/bulletDistance))
		luainit:storeBullet()		
		
		x = x - distancePerQuad
		y = y + distancePerQuad
		
	end
	
	for i=1,bulletsPerQuad,1 do
	
		luainit:newbullet()
		luainit:setForce(x,y)
		luainit:storeBullet()
		
		luainit:newbullet()
		luainit:setForce(x+(distancePerQuad/bulletDistance),y+(distancePerQuad/bulletDistance))
		luainit:storeBullet()		
		
		x = x + distancePerQuad
		y = y + distancePerQuad
		
	end
	
	for i=1,bulletsPerQuad,1 do
		
		luainit:newbullet()
		luainit:setForce(x,y)
		luainit:storeBullet()
		
		luainit:newbullet()
		luainit:setForce(x+(distancePerQuad/bulletDistance),y-(distancePerQuad/bulletDistance))
		luainit:storeBullet()		
		
		x = x + distancePerQuad
		y = y - distancePerQuad
		
	end
	
	for i=1,bulletsPerQuad,1 do
				
		luainit:newbullet()
		luainit:setForce(x,y)
		luainit:storeBullet()
		
		luainit:newbullet()
		luainit:setForce(x-(distancePerQuad/bulletDistance),y-(distancePerQuad/bulletDistance))
		luainit:storeBullet()		
		
		x = x - distancePerQuad
		y = y - distancePerQuad
		
	end

end

-- A sphere like pattern with double line of shots (very similar the one before )
-- bulletsNum: The number of bullets to shoot in 360 degree
-- bulletForce: How fast the bullets go (advised a number from 1.0(Slow) to 2.0 (Very Fast) )
-- bulletDistance: Distance between the bullets on the double line ( works a little reversed, 
--                 being 1.0 (overlaps the next line, so it's like the normal sphere pattern) and 7.0 (Very large double line) )
--                 The smaller the number the more closed is the double line
--                 Do not use numbers less than 1.0!!
function DoubleLineSpherePattern2(bulletsNum, bulletForce, bulletDistance, luainit)

local bulletsPerQuad = bulletsNum/4
local distancePerQuad = (4.0/bulletsNum)*bulletForce

local x = 0.0
local y = -1.0 * bulletForce

	for i=1,bulletsPerQuad,1 do
	
		luainit:newbullet()
		luainit:setForce(x,y)
		luainit:storeBullet()
		
		x = x - distancePerQuad
		y = y + distancePerQuad
		
		luainit:newbullet()
		luainit:setForce(x-(distancePerQuad/bulletDistance),y+(distancePerQuad/bulletDistance))
		luainit:storeBullet()		
		
		x = x - distancePerQuad
		y = y + distancePerQuad
		
	end
	
	for i=1,bulletsPerQuad,1 do
	
		luainit:newbullet()
		luainit:setForce(x,y)
		luainit:storeBullet()
		
		x = x + distancePerQuad
		y = y + distancePerQuad
		
		luainit:newbullet()
		luainit:setForce(x+(distancePerQuad/bulletDistance),y+(distancePerQuad/bulletDistance))
		luainit:storeBullet()		
		
		x = x + distancePerQuad
		y = y + distancePerQuad
		
	end
	
	for i=1,bulletsPerQuad,1 do
		
		luainit:newbullet()
		luainit:setForce(x,y)
		luainit:storeBullet()
		
		x = x + distancePerQuad
		y = y - distancePerQuad
		
		luainit:newbullet()
		luainit:setForce(x+(distancePerQuad/bulletDistance),y-(distancePerQuad/bulletDistance))
		luainit:storeBullet()		
		
		x = x + distancePerQuad
		y = y - distancePerQuad
		
	end
	
	for i=1,bulletsPerQuad,1 do
				
		luainit:newbullet()
		luainit:setForce(x,y)
		luainit:storeBullet()
		
		x = x - distancePerQuad
		y = y - distancePerQuad
		
		luainit:newbullet()
		luainit:setForce(x-(distancePerQuad/bulletDistance),y-(distancePerQuad/bulletDistance))
		luainit:storeBullet()		
		
		x = x - distancePerQuad
		y = y - distancePerQuad
		
	end

end

-- A cone like pattern
-- bulletsNum: Number of bullets to shoot
-- bulletForce: How fast the bullets go (advised a number from 1.0(Slow) to 2.0 (Very Fast) )
-- angle: angle between bullets (advised a number from 0.02 (Very Small Cone) to 1.7 (Very Wide Cone, max angle for 10 bullets))
function BulletCone(bulletsNum, bulletForce, angle, luainit)

	local x = angle * (bulletsNum/2)
	
	for i=1,bulletsNum,1 do
	
		luainit:newbullet()
		luainit:setForce(x,bulletForce)
		luainit:storeBullet()
		
		x = x-angle
	
	end

end