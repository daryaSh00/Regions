$(document).ready(function () {
    $('#provinceTable').DataTable({
        "ajax": {
            "url": "/Province/GetProvince",
            "type": "GET",
            "datatype": "json",
            "dataSrc": "data"
        },
        "columns": [
            { "data": "name" },
            {
                "data": "id",
                "render": function (data, type, row) {
                    return '<button class="btn btn-info btn-sm rename-btn" data-id="' + data + '">افزودن ستاره به استان</button>';
                },
                "orderable": false
            }
        ],
        "language": {
            "emptyTable": "هیچ استانی یافت نشد",
            "processing": "در حال بارگذاری...",
            "search": "جستجو:",
            "lengthMenu": "نمایش _MENU_ ردیف",
            "info": "نمایش _START_ تا _END_ از _TOTAL_ ردیف",
            "paginate": {
                "first": "اولین",
                "last": "آخرین",
                "next": "بعدی",
                "previous": "قبلی"
            }
        },
        "responsive": true,
        "paging": true,
        "searching": true,
        "ordering": true,
        "info": true,
        "dir": "rtl"
    });

    $('#provinceTable').on('click', '.rename-btn', function () {
        var provinceId = $(this).data('id');
        window.location.href = '/Province/RenameProvince?id=' + provinceId;
    });
});