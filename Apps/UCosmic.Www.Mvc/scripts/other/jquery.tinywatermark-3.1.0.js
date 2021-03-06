(function($) {
	$.fn.watermark = function(c, t) {
		var e = function(e) {
			var i = $(this);
			if (!i.val()) {
				var w = t || i.attr('title'), $c = $($("<div />").append(i.clone()).html().replace(/type=\"?password\"?/, 'type="text"')).val(w).addClass(c);
				i.replaceWith($c);
				$c.focus(function() {
					$c.replaceWith(i); setTimeout(function() {i.focus();}, 1);
				})
				.change(function(e) {
					i.val($c.val()); $c.val(w); i.val() && $c.replaceWith(i);
				})
				.closest('form').submit(function() {
					$c.replaceWith(i);
				});
			}
		};
		return $(this).live('blur change', e).change();
	};
})(jQuery);