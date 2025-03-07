// wwwroot/js/city.js
$(document).ready(function () {
    $('#cityTable').DataTable({
        "ajax": {
            "url": "/City/GetCities",
            "type": "GET",
            "datatype": "json",
            "dataSrc": "data"
        },
        "columns": [
            { "data": "cityName" },
            { "data": "provinceName" }
        ],
        "language": {
            "emptyTable": "هیچ شهری یافت نشد",
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