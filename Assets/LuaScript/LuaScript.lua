local  util = require 'util'
local x = 1
-- Hello Word
print('hello,this message from lua Script !')

xlua.hotfix(CS.Lab,'Func',function(self)
	print('this message is from lua hahah ')
end)

xlua.hotfix(CS.Lab,'Play',function(self)
	
	--loop()
	--print(max(1,2))
	--LuaClassTest()
	--LuaOperator()
	--LuaIterator()
	--local n,m = LuaRetun()
	--print("n:",n,"m",m)
end)

xlua.private_accessible(CS.Lab)
util.hotfix_ex(CS.Lab,"Play",function(self)
	-- 先执行原来的逻辑
	self.Play(self) 
	-- 再执行新的逻辑
	print("do lua 21111")
	print("x = ".. 1)

	print(tonumber("123"))
	print(tostring(123))
	local  x = 1.1
	print(tonumber(x))

	local  y = 100

	y = y - 10

	print(y)

	CS.Lab1.Instance:Func()
	CS.Lab1.Instance:Func1("123")
	--print(100 * 10 / 100)
	--print(math.ceil(100 * 10 / 100))
	--print(CS.Lab1.Instance.Num)
	self.LongmudaLab(self)
	local  x = "商品可购买次数x"..1
	print(x)
	--self:WriteAllLanguageInTexts(self,"123")

	print(self._student.Age)

	print(self._student.Height)

	print(self._student.A)


end)

--可以一次返回多个参数
function LuaRetun( ... )
	x = 10
	y = 100
	return  x,y
end

--迭代器
function LuaIterator( ... )

	--[[
	array = {"arr1","arr2"}
	--pairs
	for key , value in pairs(array) do
		print(key,value)
	end
	--ipairs
	for  key , value in ipairs(array) do
		print(key,value)
	end
	]]

	myTable = {}
	myTable[1] = "111"
	myTable[2] = "222"
	myTable[4] = "444"
	--pairs
	print(">>>>pairs:")
	for k,v in pairs(myTable) do
		print(k,v)
	end

	--ipairs 遍历一组数组，如果使用ipairs，遇到非连续的整形key就会停止便利，
	print(">>>>ipairs:")
	for i,v in ipairs(myTable) do
		print(i,v)
	end
end

function  loop()

	local  x = 1
	while(x < 5)
	do
		print('循环...')
		x = x + 1
	end

end


function max(num1,num2 )

	if(num1 > num2) then
		result = num1
	else
		result = num2
	end

	return result
end

--table.sort( tablename, sortfunction )


function  LuaClassTest( ... )
	--初始化表
	myTable = {}
	--myTable的类型
	print(type(myTable))

	--指定值
	myTable[1] = "lua"

	print(myTable[1])
	

	myTable["wow"] = "修改前"
	print("myTable 索引为1的元素是",myTable[1])
	print("myTable 索引为wow的元素是" ,myTable["wow"])


	alternateTable = myTable

	print("alternateTable 索引为1的元素是",alternateTable[1])
	print("alternateTable 索引为wow的元素是" ,alternateTable["wow"])

	alternateTable["wow"] = "修改后"

	print("myTable 索引为wow的元素是" ,myTable["wow"])
	print("alternateTable 索引为wow的元素是" ,alternateTable["wow"])

	--释放变量
	alternateTable = nil
	
	print("alternateTable 是",alternateTable)
	-- 结果:alternateTable 是 nil


	--被释放之后，无法再进行访问 报错
	--print("alternateTable 索引为wow的元素是" ,alternateTable["wow"])

	--myTable 仍然可以访问
	print("myTable 索引为wow的元素是" ,myTable["wow"])

	--移除引用
	myTable = nil
	print("myTable 是",myTable)

end

function  LuaOperator( ... )
	print(10^2)
	print(4^3 * 16^4 * 16^3)
end

--[[
xlua.private_accessible(CS.Lab)
util.hotfix_ex(CS.Lab,'Play',function(self)
	self:Play()
	print("do lua 2")
end)
]]

--










local util=require 'xlua/util'
print("热更价格差异")

-- 热更价格差异
xlua.private_accessible(CS.GemShopStoreItemController)
xlua.hotfix(CS.GemShopStoreItemController,'OnClickBtn',function (self)
	print("热更价格差异")
	local title = "提 示"
	local otherTip = "购买价格刷新后重置"
	local date = self._data
	print(date == nil)
	print(date)
	
	local num = CS.System.Convert.ToInt32(self._data.buy_num)
	print(num == nil)
		
	local temp = CS.GemShopModel.MAX_BUY_LIMIT - num
	local allowBuyNum = 0
	if(temp > 0)then
		allowBuyNum = temp
	else
		allowBuyNum = 0
	end
	local tip = "商品可购买次数x"..allowBuyNum
	local cost = CS.System.Convert.ToInt32(self._data.price)
   	local discount = CS.System.Convert.ToInt32(CS.GemShopModel.Instance:GetDiscountByType(self._data.type, self._data.award))

	-- 买资源回调事件
	local BuyResourceAction  = 	function()
	 	CS.TopMessageBarController.Instance:ShowMessageLanguage("UITourMatch/Store/Tip/ExchangeSuccess")
	    CS.UserDataManager.Instance.myTeam.money = CS.UserDataManager.Instance.myTeam.money - (math.ceil(cost * discount / 100.0))
	    CS.com.galasports.basketballmaster.HomeUIController.instance:ShowGetAwardEffect(self._data.award)
	    CS.com.galasports.basketballmaster.Utils.Event.EventDispatcher.TriggerEvent(CS.Events.REFRESH_SALARY)
	end

	--弹窗确定回调事件
	local  OnConfirmCallBack =  function()
	 	if(allowBuyNum > 0) then
	 		 if (CS.UserDataManager.Instance.myTeam.money >= (math.ceil(cost * discount / 100.0))) then
	 		 	self:BuyResource(BuyResourceAction)
	 		 else
	 		 	CS.TopMessageBarController.Instance:ShowMessageLanguage("UITips/BuyResource/BuyTips05")
	 		 end
	 	else
	 		CS.TopMessageBarController.Instance:ShowMessageLanguage("UIGift/NBAShop/MaxLimitBuyTip")
	 	end
	end
   
   	IsNull(title)
   	IsNull("")
   	IsNull(cost)
   	IsNull(discount)
   	IsNull(self._data.award)
   	IsNull(otherTip)
   	IsNull(tip)
   	IsNull(OnConfirmCallBack)
   	IsNull(CS.AlterType.Gem)
   	IsNull(nil)
   	IsNull(false)

	
	
 	CS.PopupController.instance:PopupShopAlert(title,"", cost, discount, self._data.award, otherTip, tip,OnConfirmCallBack,CS.AlterType.Gem, nil, false)
end)


function  IsNull(obj)
	if(obj == nil) then
		print(obj.."is nil")
	end
end



--修复宝石商店计算宝石数量取整问题
xlua.private_accessible(CS.PopupController)
util.hotfix_ex(CS.PopupController,"PopupShopAlert",function(self,title,tip,cost,discount,award,otherTips,contentTip,callback,type,closeCallback,userStaticBg)
	--CS.UnityEngine.Debug.LogError("<color='#990066'>Lua Called PopupShopAlert</color>")
	self:PopupShopAlert(title,tip,cost,discount,award,otherTips,contentTip,callback,type,closeCallback,userStaticBg)
	if(type == CS.AlterType.Gem) then
		local window = CS.UnityEngine.GameObject.Find("ShopAlert(Clone)")
		if(window ~= nil) then
				local gemBtnTrans = window.transform:Find("BtnGem")
				if(gemBtnTrans ~= nil) then
					 local costTxt = gemBtnTrans.transform:Find("Text"):GetComponent("Text");
					 if(costTxt ~= nil) then
						costTxt.text = math.ceil(discount * cost / 100.0)
					 end
				end
			end
	end
end)