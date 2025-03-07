// wwwroot/js/district.js
$(document).ready(function () {
    $('#districtTable').DataTable({
        "ajax": {
            "url": "/District/GetDistricts",
            "type": "GET",
            "datatype": "json",
            "dataSrc": "data"
        },
        "columns": [
            { "data": "districtName" },
            { "data": "cityName" },
            { "data": "provinceName" }
        ],
        "language": {
            "emptyTable": "هیچ ناحیه ای یافت نشد",
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
});