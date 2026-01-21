$(function () {
    $('[id*=txtKhachHang]').typeahead({
        hint: true,
        highlight: true,
        minLength: 1,
        scrollHeight: 100,
        source: function (request, response) {
            $.ajax({
                url: '<%=ResolveUrl("~/BanHang.aspx/GetCustomers") %>',
                data: "{ 'prefix': '" + request + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    items = [];
                    map = {};
                    $.each(data.d, function (i, item) {
                        var id = item.split('-')[0];
                        var name = item.split('-')[1];
                        var phuong = item.split('-')[2];
                        var diachi = item.split('-')[3];
                        var so_dt = item.split('-')[4];
                        map[name] = { id: id, name: name, phuong: phuong, diachi: diachi, dt: so_dt };
                        items.push(name);
                        //items.push(phuong);
                        //items.push(diachi);
                    });
                    response(items);
                    $(".dropdown-menu").css("height", "auto");
                    //$(".dropdown-menu").css("width", "200px");
                },
                error: function (response) {
                    alert(response.responseText);
                },
                failure: function (response) {
                    alert(response.responseText);
                }
            });
        },
        displayText: function (item) {
            return '<h6>' + map[item].name + '</h6>' + '<p >' + map[item].phuong + '</p> ' + '<p>Địa chỉ:' + map[item].diachi + '</p>';

        },
        afterSelect: function (item) {
            $('[id*=txtKhachHang]').val(map[item].name);
        },
        updater: function (item) {
            $('[id*=hfKHId]').val(map[item].id);
            $('[id*=hftenKH]').val(map[item].name);
            document.getElementById("lblTenKH").textContent = map[item].name;
            document.getElementById("lblDT").textContent = map[item].so_dt;
            document.getElementById("lblDiaChi").textContent = map[item].diachi;
            document.getElementById("lblDiaBan").textContent = map[item].phuong;
            return item;
        }
    });
});
function getDate() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();
    var h = today.getHours();
    var min = today.getMinutes();
    var s = today.getSeconds()
    if (h < 10) {
        h = '0' + h
    }
    if (min < 10) {
        min = '0' + min
    }
    if (s < 10) {
        s = '0' + s
    }
    var time = h + ":" + min + ":" + s;
    if (dd < 10) {
        dd = '0' + dd
    }
    if (mm < 10) {
        mm = '0' + mm
    }
    today = dd + '/' + mm + '/' + yyyy + ' ' + time;
    document.getElementById('lblngaythang').textContent = 'Ngày ' + dd + ' tháng ' + mm + ' năm ' + yyyy;
    return today;
};
function getSoHD() {
    var today = new Date();
    var yyyy = today.getFullYear();
    $.ajax({
        url: '<%=ResolveUrl("~/BanHang.aspx/GetSoHD") %>',
        data: "{ 'prefix': '" + yyyy + "'}",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            items = [];
            map = {};
            var sohd;
            $.each(data.d, function (i, item) {
                sohd = item[0];
            });
            //console.log(sohd);
            document.getElementById('txtID').value = sohd;
            $('[id*=hfsoHD]').val(sohd);
            document.getElementById("lblSoHD").textContent = sohd;
            // response(items);
        },
        error: function (response) {
            alert(response.responseText);
        },
        failure: function (response) {
            alert(response.responseText);
        }
    });

};
window.onload = function () {
    document.getElementById('txtdate').value = getDate();
    getSoHD();
    $('[id*=hfNgayBan]').val(getDate());

};

function getTotal() {
    var sl20 = document.getElementById("sl20").value;
    var sl30 = document.getElementById("sl30").value;
    var sl50 = document.getElementById("sl50").value;
    var slkeg1l = document.getElementById("slkeg1l").value;
    var slkeg2l = document.getElementById("slkeg2l").value;
    var slbiachai = document.getElementById("slbiachai").value;
    var slbialit = document.getElementById("slbialit").value;
    // console.log(sl20 + '-'+ sl30 + '-'+ sl50 + '-'+ slkeg1l + '-' + slkeg2l);
    //truyen tham so
    $('[id*=hfBH20]').val(sl20);
    $('[id*=hfBH30]').val(sl30);
    $('[id*=hfBH50]').val(sl50);
    $('[id*=hfBK1]').val(slkeg1l);
    $('[id*=hfBK2]').val(slkeg2l);
    $('[id*=hfBC]').val(slbiachai);
    $('[id*=hfBL]').val(slbialit);
    //view tong
    $('[id*=txtTongSoBia]').val(sl20 * 20 + sl30 * 30 + sl50 * 50 + slbialit);

    $('[id*=txtTongChai]').val(slbiachai)
    if (slkeg1l == 0 && slkeg2l == 0) {
        $('[id*=txtTongKeg]').val(0);
    }
    else {
        if (slkeg1l == 0) {
            $('[id*=txtTongKeg]').val(slkeg2l + ' (Keg2L)');

        }
        else {
            if (slkeg2l == 0) {
                $('[id*=txtTongKeg]').val(slkeg1l + ' (Keg1L)');
            } else {
                $('[id*=txtTongKeg]').val(slkeg1l + ' (Keg1L)' + ' - ' + slkeg2l + ' (Keg2L)');
            }
        }
    }

};
function validate() {
    var tongbiahoi = document.getElementById("txtTongSoBia").value;
    var tongkeg = document.getElementById("txtTongKeg").value;
    var tongchai = document.getElementById("txtTongChai").value;
    var slkeg1l = document.getElementById("slkeg1l").value;
    var slkeg2l = document.getElementById("slkeg2l").value;
    var khachhang = document.getElementById("txtKhachHang").value;
    //console.log(khachhang + '-' + tongbia);
    if (khachhang == '' || (tongbiahoi + slkeg1l + slkeg2l + tongchai) <= 0) {
        // $(".alert").show();
        alert("Bạn phải nhập khách hàng và số lượng bia");
        return false;
    } else {
        if (tongbiahoi > 0) {
            $("#DSSanPham tbody").append(
              "<tr>" +
                "<td></td>" +
                "<td>Bia hơi</td>" +
                "<td>Lít</td>" +
                 "<td>" + tongbiahoi + "</td>" +
              "</tr>");
        }
        if (slkeg1l > 0) {
            $("#DSSanPham tbody").append(
                 "<tr>" +
                   "<td></td>" +
                   "<td>Bia keg 1L</td>" +
                   "<td>Keg</td>" +
                    "<td>" + slkeg1l + "</td>" +
                 "</tr>");
        }
        if (slkeg2l > 0) {
            $("#DSSanPham tbody").append(
                 "<tr>" +
                   "<td></td>" +
                   "<td>Bia keg 2L</td>" +
                   "<td>Keg</td>" +
                    "<td>" + slkeg2l + "</td>" +
                 "</tr>");
        }
        if (tongchai > 0) {
            $("#DSSanPham tbody").append(
                 "<tr>" +
                   "<td></td>" +
                   "<td>Bia chai</td>" +
                   "<td>Chai</td>" +
                    "<td>" + tongchai + "</td>" +
                 "</tr>");
        }
    }
};

function PrintPanel() {
    var panel = document.getElementById("pnlContents");
    var printWindow = window.open('', '', 'height=800,width=1000');
    printWindow.document.write('<html><head><title>Phiếu nhập kho thiết thị thu hồi</title>');
    printWindow.document.write('<style type="text/css">');
    printWindow.document.write(' .table-print > thead > tr > th, .table-print > tbody > tr > th, .table-print > tfoot > tr > th, .table-print > thead > tr > td, .table-print > tbody > tr > td, .table-print > tfoot > tr > td {');
    printWindow.document.write('border: 1px solid #000000;width:806px;');
    printWindow.document.write('}</style></head><body><div style="width:806px">');
    printWindow.document.write(panel.innerHTML);
    printWindow.document.write('</div></body></html>');
    printWindow.document.close();
    setTimeout(function () {
        printWindow.print();
    }, 500);
    return false;
}