# InriverModelBuilder
A simple C# model builder for Inriver PIM

It allows you to query the inriver REST API and generate simple C# classes from the entitytypes allowing for further easy mapping in your code. It talks to the /api/v1.0.0/model/entitytypes endpoint on https://apieuw.productmarketingcloud.com
Its not advanced, and yet pretty untested in real world. But someone might find it usefull

# Arguments
call it with InriverModelBuilder.exe APISTRING FILENAME.cs 
where the APISTRING is the same you would use at https://apieuw.productmarketingcloud.com/swagger/ui/index#/
