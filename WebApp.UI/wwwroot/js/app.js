function reloadTheme() {
	loadCssFiles();
	loadJsFiles();
}

function loadCssFiles() {
	loadCssFile("/css/app.css");
	if (isMethodic()) {
		loadCssFile("/_content/Methodic.Blazor.UI/css/bootstrap-icons.min.css");
	}
	loadCssFile("/_content/Methodic.Blazor.UI/css/light.css");
	loadCssFile("/_content/Methodic.Blazor.UI/css/app.css");
	loadCssFile("/css/kendo-light.css");
}

function loadJsFiles() {
	if (!isMethodic()) {
		loadJsFile("/_content/Telerik.UI.for.Blazor.Trial/js/telerik-blazor.js");
		loadJsFile("/_content/Methodic.Blazor.UI/js/app.js");
	}
	else {		
		loadJsFile("https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js");
	}
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

function isMethodic() {
	return window.location.href.includes('methodic-admin');
}