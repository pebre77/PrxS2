﻿/// <summary>Constructor called from DependencyLookupControl</summary>
DependencyLookup = function (clientId, initCall, size, autoPostBack, title) {
    this.ClientId = clientId;
    this.PanelId = clientId + "_Panel";
    this.InitCall = initCall;
    this.LookupControls = new Array();
    this.CurrentIndex = 0;
    this.Size = size + "px";
    this.AutoPostBack = autoPostBack;
    this.panel = null;
    this.Title = title;
};

DependencyLookup.prototype.CanShow = function () {
    var inPostBack = false;
    if (Sys) {
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        inPostBack = prm.get_isInAsyncPostBack();
    }
    if (!inPostBack) {
        return true;
    }
    else {
        var id = this.ClientId + "_obj";
        var handler = function () {
            window[id].Show('');
        }
        Sage.SyncExec.call(handler);
        return false;
    }
};

DependencyLookup.prototype.Show = function () {
    if (this.CanShow()) {
        if (this.panel == null) {
            var lookup = document.getElementById(this.PanelId);
            lookup.style.display = "block";
            this.panel = new YAHOO.widget.Panel(this.PanelId, { visible: false, width: this.Size, fixedcenter: true, constraintoviewport: true, /*x:250, y:200,*/underlay: "shadow", draggable: true, iframe: true, modal: false });
            this.panel.render();
            if ((this.CurrentIndex == 0) || (this.LookupControls[i] != undefined)) {
                this.Init();
            }
            for (var i = 0; i < this.CurrentIndex; i++) {
                if (this.LookupControls[i] != undefined) {
                    var text = document.getElementById(this.LookupControls[i].TextId);
                    var seedVal = "";
                    if (i > 0) {
                        seedVal = this.GetSeeds(i);
                    }
                    if ((text.value != "") || (seedVal != "") || (i == 0)) {
                        this.LookupControls[i].CurrentValue = text.value;
                        var listId = this.LookupControls[i].ListId;
                        var list = document.getElementById(listId);
                        if (list.options.length == 0) {
                            this.LookupControls[i].LoadList(seedVal);
                        }
                    }
                }
            }
        }
        this.panel.show();
    }
};

DependencyLookup.prototype.AddControl = function (baseId, listId, textId, type, displayProperty, seedProperty) {
    var dependCtrl = new dependControl(baseId, listId, textId, type, displayProperty, seedProperty);
    this.LookupControls[this.CurrentIndex] = dependCtrl;
    this.CurrentIndex++;
};

DependencyLookup.prototype.AddFilters = function (FilterProp, FilterValue) {
    var dependCtrl = new dependControl(listId, textId, type, displayProperty, seedProperty);
    this.LookupControls[this.CurrentIndex] = dependCtrl;
    this.CurrentIndex++;
};

DependencyLookup.prototype.SelectionChanged = function (index) {
    if ((index + 1) < this.CurrentIndex) {
        this.LookupControls[index + 1].LoadList(this.GetSeeds(index + 1));
        for (var i = index + 2; i < this.CurrentIndex; i++) {
            this.LookupControls[i].ClearList();
        }
    }
};

DependencyLookup.prototype.Ok = function () {
    this.panel.hide();
    for (var i = 0; i < this.CurrentIndex; i++) {
        var text = document.getElementById(this.LookupControls[i].TextId);
        var list = document.getElementById(this.LookupControls[i].ListId);
        if ((list.selectedIndex != undefined) && (list.selectedIndex != -1)) {
            text.value = list.options[list.selectedIndex].text;
        }
        else {
            text.value = "";
        }
        this.InvokeChangeEvent(text);
    }
    if (this.AutoPostBack) {
        if (Sys) {
            Sys.WebForms.PageRequestManager.getInstance()._doPostBack(this.ClientId, null);
        }
        else {
            document.forms(0).submit();
        }
    }
};

DependencyLookup.prototype.Init = function () {
    eval(this.InitCall);
};

DependencyLookup.prototype.InvokeChangeEvent = function (cntrl) {
    if (document.createEvent) {
        //FireFox
        var evObj = document.createEvent('HTMLEvents');
        evObj.initEvent('change', true, true);
        cntrl.dispatchEvent(evObj);
    }
    else {
        //IE
        cntrl.fireEvent('onchange');
    }
};

DependencyLookup.prototype.GetSeeds = function (index) {
    var result = "";
    for (var i = index; i > 0; i--) {
        var dependParent = this.LookupControls[i - 1];
        var dependChild = this.LookupControls[i];
        var list = document.getElementById(dependParent.ListId);
        if (list.selectedIndex == -1) {
            return result;
        }
        var seed = list.options[list.selectedIndex];
        result += dependChild.SeedProperty + "," + seed.text + "|"
    }
    result = result.substr(0, result.length - 1);
    return result;
};

dependControl = function (baseId, listId, textId, type, displayProperty, seedProperty) {
    this.BaseId = baseId;
    this.ListId = listId;
    this.TextId = textId;
    this.Type = type;
    this.DisplayProperty = displayProperty;
    this.SeedProperty = seedProperty;
    this.CurrentValue = "";
};

dependControl.prototype.LoadList = function (seedValue) {
    var vURL = "SLXDependencyHandler.aspx?cacheid=" + this.BaseId + "&type=" + this.Type + "&displayprop=" + this.DisplayProperty + "&seeds=" + seedValue + "&currentval=" + this.CurrentValue;
    Ext.Ajax.request({
        url: vURL,
        callback: this.HandleHttpResponse,
        scope: this
    });
};

dependControl.prototype.HandleHttpResponse = function (options, isSuccess, response) {
    if (isSuccess) {
        var list = document.getElementById(this.ListId);

        list.innerHTML = "";

        var items = response.responseText.split("|");
        for (var i = 0; i < items.length; i++) {
            if (items[i] == "") continue;
            var parts = items[i].split(",");
            var oOption = document.createElement("OPTION");
            list.options.add(oOption);
            if (parts[0].charAt(0) == '@') {
                parts[0] = parts[0].substr(1);
                oOption.selected = true;
            }
            oOption.innerHTML = parts[1];
            oOption.value = parts[0];
        }
    }
};

dependControl.prototype.ClearList = function () {
    var list = document.getElementById(this.ListId);

    list.innerHTML = "";

};

DependencyLookup.prototype.close = function () {
    this.panel.hide();
};
