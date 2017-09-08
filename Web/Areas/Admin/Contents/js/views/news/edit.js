$(function () { // document ready shortcut
  $("#Tags").tagsinput({
  });

  $('.dtp').datetimepicker({
    locale: 'tr',
    ignoreReadonly: true

  });

  CKEDITOR.replace('Content', {
    language: 'tr',
    uiColor: '#F7B42C',
    htmlEncodeOutput: true,
  });
});