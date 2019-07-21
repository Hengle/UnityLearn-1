-- Hello Word
print('hello,this message from lua Script !')

xlua.hotfix(CS.Lab,'Func',function(self)
	print('this message is from lua hahah ')
end)

xlua.hotfix(CS.Lab,'Play',function(self)
	
	--loop()
	--Debug(max(1,2))
	--LuaClassTest()
	LuaOperator()
end)

function  Debug(obj)
	
	print(obj)

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
	Debug(type(myTable))

	--指定值
	myTable[1] = "lua"

	Debug(myTable[1])
	

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








--util.hotfix_ex(CS.,'',function(self,number)
--	self.GoldChange(self,number)

--	print('1.3.1 GoldChange HotFix Success!')
--end)