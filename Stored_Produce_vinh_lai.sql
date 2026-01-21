CREATE PROCEDURE TEST @ky_hd NVARCHAR(50)  
AS
    select tba.id_tram_bien_ap, tba.ten_viet_tat, tba.ten_tram_bien_ap, ISNULL(muc1.sl,'0') as muc1, ISNULL(muc2.sl,'0') as muc2, ISNULL(muc3.sl,'0') as muc3,ISNULL(muc4.sl,'0') as muc4,ISNULL(muc5.sl,'0') as muc5,ISNULL(muc6.sl,'0') as muc6 ,
    ISNULL(SX.sl,'0') as SX, ISNULL(TDKD.sl,'0') as TDKD, ISNULL(KD.sl,'0') as KD, ISNULL(CS.sl,'0') as CS,ISNULL(DX.sl,'0') as DX,ISNULL(NT.sl,'0') as NT,ISNULL(BN.sl,'0') as BN,ISNULL(GBT.sl,'0') as GBT,ISNULL(GCD.sl,'0') as GCD,ISNULL(GTD.sl,'0') as GTD , 
    ISNULL(muc1.sl,'0') + ISNULL(muc2.sl,'0') + ISNULL(muc3.sl,'0') + ISNULL(muc4.sl,'0') + ISNULL(muc5.sl,'0') + ISNULL(muc6.sl,'0') + ISNULL(SX.sl,'0') + ISNULL(TDKD.sl,'0') + ISNULL(KD.sl,'0') + ISNULL(CS.sl,'0') + ISNULL(DX.sl,'0') + ISNULL(NT.sl,'0') + ISNULL(BN.sl,'0')  + ISNULL(GBT.sl,'0') + ISNULL(GCD.sl,'0') + ISNULL(GTD.sl,'0') TongCong


    -- Trạm
    from (select id_tram_bien_ap,ten_viet_tat,ten_tram_bien_ap from tram_bien_ap) as tba 
    -- Cột 1: Mức 1
    LEFT OUTER JOIN 
    (select hd.id_tram_bien_ap,sum(hdct.so_luong) sl from hoa_don_chi_tiet hdct, hoa_don hd 
    where hd.id = hdct.id_hoa_don and hd.ky_hd like @ky_hd and hdct.dien_giai = N'Mức 1' and hd.trang_thai=2 and hd.dien_nang_tt > 0 and hd.dien_nang_tt > 0 group by id_tram_bien_ap) as muc1 
    ON muc1.id_tram_bien_ap = tba.id_tram_bien_ap 
    -- Cột 2: Mức 2
    LEFT OUTER JOIN 
    (select hd.id_tram_bien_ap,sum(hdct.so_luong) sl from hoa_don_chi_tiet hdct, hoa_don hd 
    where hd.id = hdct.id_hoa_don and hd.ky_hd like @ky_hd and hdct.dien_giai = N'Mức 2' and hd.trang_thai=2 and hd.dien_nang_tt > 0 and hd.dien_nang_tt > 0 group by id_tram_bien_ap) as muc2 
    ON muc2.id_tram_bien_ap = tba.id_tram_bien_ap 
    -- Cột 3: Mức 3
    LEFT OUTER JOIN 
    (select hd.id_tram_bien_ap,sum(hdct.so_luong) sl from hoa_don_chi_tiet hdct, hoa_don hd 
    where hd.id = hdct.id_hoa_don and hd.ky_hd like @ky_hd and hdct.dien_giai = N'Mức 3' and hd.trang_thai=2 and hd.dien_nang_tt > 0 group by id_tram_bien_ap) as muc3 
    ON muc3.id_tram_bien_ap = tba.id_tram_bien_ap 

    -- Cột 4: Mức 4
    LEFT OUTER JOIN 
    (select hd.id_tram_bien_ap,sum(hdct.so_luong) sl from hoa_don_chi_tiet hdct, hoa_don hd 
    where hd.id = hdct.id_hoa_don and hd.ky_hd like @ky_hd and hdct.dien_giai = N'Mức 4' and hd.trang_thai=2 and hd.dien_nang_tt > 0 group by id_tram_bien_ap) as muc4 
    ON muc4.id_tram_bien_ap = tba.id_tram_bien_ap 
    -- Cột 5: Mức 5
    LEFT OUTER JOIN 
    (select hd.id_tram_bien_ap,sum(hdct.so_luong) sl from hoa_don_chi_tiet hdct, hoa_don hd 
    where hd.id = hdct.id_hoa_don and hd.ky_hd like @ky_hd and hdct.dien_giai = N'Mức 5' and hd.trang_thai=2 and hd.dien_nang_tt > 0 group by id_tram_bien_ap) as muc5 
    ON muc5.id_tram_bien_ap = tba.id_tram_bien_ap 
    -- Cột 6: Mức 6
    LEFT OUTER JOIN 
    (select hd.id_tram_bien_ap,sum(hdct.so_luong) sl from hoa_don_chi_tiet hdct, hoa_don hd 
    where hd.id = hdct.id_hoa_don and hd.ky_hd like @ky_hd and hdct.dien_giai = N'Mức 6' and hd.trang_thai=2 and hd.dien_nang_tt > 0 group by id_tram_bien_ap) as muc6 
    ON muc6.id_tram_bien_ap = tba.id_tram_bien_ap 
    -- Cột SX: Sản xuất
    LEFT OUTER JOIN 
    (select hd.id_tram_bien_ap,sum(hdct.so_luong) sl from hoa_don_chi_tiet hdct, hoa_don hd 
    where hd.id = hdct.id_hoa_don and hd.ky_hd like @ky_hd and hdct.dien_giai = N'Điện sản xuất' and hd.trang_thai=2 and hd.dien_nang_tt > 0 group by id_tram_bien_ap) as SX 
    ON SX.id_tram_bien_ap = tba.id_tram_bien_ap 
    -- Cột TĐKD: Thấp điểm kinh doanh
    LEFT OUTER JOIN 
    (select hd.id_tram_bien_ap,sum(hdct.so_luong) sl from hoa_don_chi_tiet hdct, hoa_don hd 
    where hd.id = hdct.id_hoa_don and hd.ky_hd like @ky_hd and hdct.dien_giai = N'TĐKD' and hd.trang_thai=2 and hd.dien_nang_tt > 0 group by id_tram_bien_ap) as TDKD 
    ON TDKD.id_tram_bien_ap = tba.id_tram_bien_ap 
    -- Cột KD: Kinh doanh
    LEFT OUTER JOIN 
    (select hd.id_tram_bien_ap,sum(hdct.so_luong) sl from hoa_don_chi_tiet hdct, hoa_don hd 
    where hd.id = hdct.id_hoa_don and hd.ky_hd like @ky_hd and hdct.dien_giai = N'Điện kinh doanh - dịch vụ' and hd.trang_thai=2 and hd.dien_nang_tt > 0 group by id_tram_bien_ap) as KD 
    ON KD.id_tram_bien_ap = tba.id_tram_bien_ap 
    -- Cột CS: Điện hành chính, sự nghiệp
    LEFT OUTER JOIN 
    (select hd.id_tram_bien_ap,sum(hdct.so_luong) sl from hoa_don_chi_tiet hdct, hoa_don hd 
    where hd.id = hdct.id_hoa_don and hd.ky_hd like @ky_hd and hdct.dien_giai = N'Điện hành chính, sự nghiệp' and hd.trang_thai=2 and hd.dien_nang_tt > 0 group by id_tram_bien_ap) as CS 
    ON CS.id_tram_bien_ap = tba.id_tram_bien_ap 
    -- Cột DX: Điện xóm
    LEFT OUTER JOIN 
    (select hd.id_tram_bien_ap,sum(hdct.so_luong) sl from hoa_don_chi_tiet hdct, hoa_don hd 
    where hd.id = hdct.id_hoa_don and hd.ky_hd like @ky_hd and hdct.dien_giai = N'Điện xóm' and hd.trang_thai=2 and hd.dien_nang_tt > 0 group by id_tram_bien_ap) as DX 
    ON DX.id_tram_bien_ap = tba.id_tram_bien_ap 
    -- Cột NT: Điện cho bệnh viện, trường học
    LEFT OUTER JOIN 
    (select hd.id_tram_bien_ap,sum(hdct.so_luong) sl from hoa_don_chi_tiet hdct, hoa_don hd 
    where hd.id = hdct.id_hoa_don and hd.ky_hd like @ky_hd and hdct.dien_giai = N'Điện cho bệnh viện, trường học' and hd.trang_thai=2 and hd.dien_nang_tt > 0 group by id_tram_bien_ap) as NT 
    ON NT.id_tram_bien_ap = tba.id_tram_bien_ap 
    -- Cột BN: Điện cho bơm nước, tưới tiêu
    LEFT OUTER JOIN 
    (select hd.id_tram_bien_ap,sum(hdct.so_luong) sl from hoa_don_chi_tiet hdct, hoa_don hd 
    where hd.id = hdct.id_hoa_don and hd.ky_hd like @ky_hd and hdct.dien_giai = N'Điện cho bơm nước, tưới tiêu' and hd.trang_thai=2 and hd.dien_nang_tt > 0 group by id_tram_bien_ap) as BN 
    ON BN.id_tram_bien_ap = tba.id_tram_bien_ap 
    -- Cột GBT: Giờ bình thường
    LEFT OUTER JOIN 
    (select hd.id_tram_bien_ap,sum(hdct.so_luong) sl from hoa_don_chi_tiet hdct, hoa_don hd 
    where hd.id = hdct.id_hoa_don and hd.ky_hd like @ky_hd and hdct.dien_giai = N'Giờ bình thường' and hd.trang_thai=2 and hd.dien_nang_tt > 0 group by id_tram_bien_ap) as GBT 
    ON GBT.id_tram_bien_ap = tba.id_tram_bien_ap 
    -- Cột GCD: Giờ cao điểm
    LEFT OUTER JOIN 
    (select hd.id_tram_bien_ap,sum(hdct.so_luong) sl from hoa_don_chi_tiet hdct, hoa_don hd 
    where hd.id = hdct.id_hoa_don and hd.ky_hd like @ky_hd and hdct.dien_giai = N'Giờ cao điểm' and hd.trang_thai=2 and hd.dien_nang_tt > 0 group by id_tram_bien_ap) as GCD 
    ON GCD.id_tram_bien_ap = tba.id_tram_bien_ap 
    -- Cột GTD: Giờ thấp điểm
    LEFT OUTER JOIN 
    (select hd.id_tram_bien_ap,sum(hdct.so_luong) sl from hoa_don_chi_tiet hdct, hoa_don hd 
    where hd.id = hdct.id_hoa_don and hd.ky_hd like @ky_hd and hdct.dien_giai = N'Giờ thấp điểm' and hd.trang_thai=2 and hd.dien_nang_tt > 0 group by id_tram_bien_ap) as GTD 
    ON GTD.id_tram_bien_ap = tba.id_tram_bien_ap 
    -- Order
    order by tba.ten_viet_tat 
GO

EXEC TEST @ky_hd = '09/2020';
