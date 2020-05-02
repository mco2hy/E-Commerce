var Category_Manage = {
    CategoryId: 0,
    Init: function (categoryId) {
        Category_Manage.CategoryId = categoryId;
        Category_Manage.Fetch(categoryId);
    },
    Fetch: function (categoryId) {
        if (categoryId == 0) return;

        $.ajax({
            type: "GET",
            url: "/kategori/getir/" + categoryId,
            data: [],
            dataType: "json",
            contentType: "application/json; charset=utf-8;",
            success: Category_Manage.Fetch_Callback
        });
    },
    Fetch_Callback: function (result) {
        console.log(result);
        $("#category-manage-catagoryname").val(result.name);
    },
    Save: function () {
        var name = $("#category-manage-categoryname").val();
        var menuId = $("#category-manage-menuid").val();
        var parentCategoryId = $("#category-manage-parentcategoryid").val();

        var data = { Name: name, MenuId: menuId, ParentCategoryId: parentCategoryId, CategoryId: Category_Manage.CategoryId };

        $.ajax({
            type: "POST",
            url: "/kategori/kaydet/",
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "application/json; charset=utf-8;",
            success: Category_Manage.Save_Callback
        });
    },
    Save_Callback: function (result) {
        cosnole.log(result);
    }
}