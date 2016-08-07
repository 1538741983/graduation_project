

F.ready(function () {

    window.mainTabStrip = F(window.mainTabStripClientID);

    var menuLis = $('.menu ul li');

    function updateLeftMenu(menuType) {

        menuLis.removeClass('selected');
        menuLis.filter('.menu-' + menuType).addClass('selected');

        window.frames['leftframe'].location.href = './menu.aspx?menu=' + encodeURIComponent(menuType);
    }

    // 点击顶部菜单，加载左侧IFrame菜单
    menuLis.click(function (e) {
        var $this = $(this);
        var classNames = /menu\-(\w+)/.exec($this.attr('class'));
        if (classNames.length === 2) {
            var menuType = classNames[1];

            updateLeftMenu(menuType);
        }
    });

    // 根据页面的Hash值，来初始化左侧IFrame菜单
    var hash = window.location.hash;
    var hashArray = /.+\/html\/(.+)\-\d+\.html/.exec(hash);
    if (hashArray && hashArray.length === 2) {
        updateLeftMenu(hashArray[1]);
    } else {
        updateLeftMenu('sys');
    }


    window.initTreeTabStrip = function (tree) {
        // 初始化主框架中的树(或者Accordion+Tree)和选项卡互动，以及地址栏的更新
        // treeMenu： 主框架中的树控件实例，或者内嵌树控件的手风琴控件实例
        // mainTabStrip： 选项卡实例
        // addTabCallback： 创建选项卡前的回调函数（接受tabConfig参数）
        // updateLocationHash: 切换Tab时，是否更新地址栏Hash值
        // refreshWhenExist： 添加选项卡时，如果选项卡已经存在，是否刷新内部IFrame
        // refreshWhenTabChange: 切换选项卡时，是否刷新内部IFrame
        // hashWindow：需要更新Hash值的窗口对象，默认为当前window
        F.initTreeTabStrip(tree, mainTabStrip, null, true, false, false);
    };

});