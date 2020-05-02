﻿var Category_Manage = {
    CategoryId: 0,
    Init: function (categoryId) {
        Category_Manage.CategoryId = categoryId;
        Category_Manage.Fetch_Menu();
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
    Fetch_Menu: function () {
        $.ajax({
            type: "GET",
            url: "/menu/getir/",
            data: [],
            dataType: "json",
            contentType: "application/json; charset=utf-8;",
            success: Category_Manage.Fetch_Menu_Callback
        });
    },
    Fetch_Menu_Callback: function (result) {
        console.log(result);
        Category_Manage.Fetch_Category();
    },
    Fetch_Category: function () {
        $.ajax({
            type: "GET",
            url: "/kategori/getir/",
            data: [],
            dataType: "json",
            contentType: "application/json; charset=utf-8;",
            success: Category_Manage.Fetch_Category_Callback
        });
    },
    Fetch_Category_Callback: function (result) {
        console.log(result);
        Category_Manage.Fetch(Category_Manage.categoryId);
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