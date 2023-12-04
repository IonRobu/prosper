function reloadTheme() {
	loadCssFiles();
	loadJsFiles();
}

function loadCssFiles() {
	loadCssFile("/css/app.css");
	loadCssFile("/_content/Methodic.Blazor.UI/css/light.css");
	loadCssFile("/_content/Methodic.Blazor.UI/css/app.css");
	loadCssFile("/css/kendo-light.css");
}

function loadJsFiles() {
	loadJsFile("/_content/Telerik.UI.for.Blazor.Trial/js/telerik-blazor.js");
	loadJsFile("/_content/Methodic.Blazor.UI/js/app.js");
}

function loadCssFile(src) {
	var customTag = document.createElement('link');
	customTag.setAttribute('rel', 'stylesheet');
	customTag.setAttribute('type', 'text/css');
	customTag.setAttribute('href', src);
	document.head.appendChild(customTag);
}

function loadJsFile(src) {
	var customTag = document.createElement('script');
	customTag.setAttribute('src', src);
	document.head.appendChild(customTag);
}