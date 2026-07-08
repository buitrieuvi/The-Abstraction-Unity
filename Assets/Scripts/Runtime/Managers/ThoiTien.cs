using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Abstraction
{
    public class ThoiTien
    {
        public List<int> Tien { get; set; } = new List<int>()
        {
            500, 200, 100, 50, 20, 10, 5, 2, 1
        };




        public List<int> TienDua(List<int> dua, int gia)
        {
            List<int> ketQua = new List<int>();

            int tongDua = dua.Sum();

            if (tongDua < gia)
            {
                Debug.LogError("Số tiền đưa vào phải lớn hơn hoặc bằng giá trị cần trả.");
                return null;
            }


            return TienTra(tongDua - gia);
        }

        public List<int> TienTra(int thoi)
        {
            List<int> ketQua = new List<int>();

            foreach (int menhGia in Tien)
            {
                while (thoi >= menhGia)
                {
                    ketQua.Add(menhGia);
                    thoi -= menhGia;
                }
            }

            return ketQua;
        }
    }
}