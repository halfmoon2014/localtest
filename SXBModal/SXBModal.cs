 
using System.Collections;
using System.Collections.Generic;
 

namespace LiLanzModel
{

    public class Ico
    {
        /// <summary>
        /// 图标路径
        /// </summary>
        string path;
        /// <summary>
        /// 图标类型(主模版,下装,下装..)
        /// </summary>
        string lx;
        /// <summary>
        /// 图标说明
        /// </summary>
        string mc;

        public string Path
        {
            get
            {
                return path;
            }

            set
            {
                path = value;
            }
        }

        public string Lx
        {
            get
            {
                return lx;
            }

            set
            {
                lx = value;
            }
        }

        public string Mc
        {
            get
            {
                return mc;
            }

            set
            {
                mc = value;
            }
        }
    }
    public class SxChdmDataContent
    {
        string sm;
        string lx;
        /// <summary>
        /// 水洗标材料对应的说明
        /// </summary>
        public string Sm
        {
            get
            {
                return sm;
            }

            set
            {
                sm = value;
            }
        }
        /// <summary>
        /// 水洗标对应货号的使用部位(上装,下装,西服三件套马甲)
        /// </summary>
        public string Lx
        {
            get
            {
                return lx;
            }

            set
            {
                lx = value;
            }
        }
    }
    public class SphhCmInfo
    {
        string sphh;
        string cm;
        string gg;
        string clr;
        string clrgg;
        int hx2isExists;
        string hx;
        string hx2;
        /// <summary>
        /// 货号
        /// </summary>
        public string Sphh
        {
            get
            {
                return sphh;
            }

            set
            {
                sphh = value;
            }
        }
        /// <summary>
        /// 货号所有的尺码
        /// </summary>
        public string Cm
        {
            get
            {
                return cm;
            }

            set
            {
                cm = value;
            }
        }
        /// <summary>
        /// 货号所有的规格
        /// </summary>
        public string Gg
        {
            get
            {
                return gg;
            }

            set
            {
                gg = value;
            }
        }
        /// <summary>
        /// 尺码对应的充绒量
        /// </summary>
        public string Clr
        {
            get
            {
                return clr;
            }

            set
            {
                clr = value;
            }
        }
        /// <summary>
        /// 尺码对应的充绒量规格
        /// </summary>
        public string Clrgg
        {
            get
            {
                return clrgg;
            }

            set
            {
                clrgg = value;
            }
        }

        public int Hx2isExists
        {
            get
            {
                return hx2isExists;
            }

            set
            {
                hx2isExists = value;
            }
        }

        public string Hx
        {
            get
            {
                return hx;
            }

            set
            {
                hx = value;
            }
        }

        public string Hx2
        {
            get
            {
                return hx2;
            }

            set
            {
                hx2 = value;
            }
        }
    }
    public class MaterialInfo2 {
        int glz;
        int sytjid;
        string value;
        string title;
        /// <summary>
        /// 成份使用的部位
        /// </summary>
        public int Glz
        {
            get
            {
                return glz;
            }

            set
            {
                glz = value;
            }
        }
        /// <summary>
        /// 排序ID
        /// </summary>
        public int Sytjid
        {
            get
            {
                return sytjid;
            }

            set
            {
                sytjid = value;
            }
        }
        /// <summary>
        /// 成份内容
        /// </summary>
        public string Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }
    }
    public class SphhInfo
    {
        string sphh;
        Dictionary<string, int> cm = new Dictionary<string, int>();
        string pm;
        string pm_sz;
        string pm_xz;
        string pm_mj3;
        string yphh;
        string bx;
        string dj;
        string zxbz;
        string aqjb;
        string xdff;
        string xdff_sz;
        string xdff_xz;
        string jgy;
        string zysx;
        string sycc;
        string zysx_sx;
        string sycc_sx;
        string zysx_kusx;
        string sycc_kusx;
        List<Ico> icoList = new List<Ico>();
        List<SxChdmDataContent> sxChdmList = new List<SxChdmDataContent>();
        List<SphhCmInfo> sphhCmInfo = new List<SphhCmInfo>();
        List<MaterialInfo2> cfList = new List<MaterialInfo2>();
        /// <summary>
        /// 货号
        /// </summary>
        public string Sphh
        {
            get
            {
                return sphh;
            }

            set
            {
                sphh = value;
            }
        }
  
        /// <summary>
        /// 品名
        /// </summary>
        public string Pm
        {
            get
            {
                return pm;
            }

            set
            {
                pm = value;
            }
        }
        /// <summary>
        /// 品名上装
        /// </summary>
        public string Pm_sz
        {
            get
            {
                return pm_sz;
            }

            set
            {
                pm_sz = value;
            }
        }
        /// <summary>
        /// 品名下装
        /// </summary>
        public string Pm_xz
        {
            get
            {
                return pm_xz;
            }

            set
            {
                pm_xz = value;
            }
        }
        /// <summary>
        /// 品名西服三件套马甲
        /// </summary>
        public string Pm_mj3
        {
            get
            {
                return pm_mj3;
            }

            set
            {
                pm_mj3 = value;
            }
        }
        /// <summary>
        /// 样号
        /// </summary>
        public string Yphh
        {
            get
            {
                return yphh;
            }

            set
            {
                yphh = value;
            }
        }
        /// <summary>
        /// 版型
        /// </summary>
        public string Bx
        {
            get
            {
                return bx;
            }

            set
            {
                bx = value;
            }
        }
        /// <summary>
        ///等级
        /// </summary>
        public string Dj
        {
            get
            {
                return dj;
            }

            set
            {
                dj = value;
            }
        }
        /// <summary>
        /// 执行标准
        /// </summary>
        public string Zxbz
        {
            get
            {
                return zxbz;
            }

            set
            {
                zxbz = value;
            }
        }
        /// <summary>
        /// 安全技术类别
        /// </summary>
        public string Aqjb
        {
            get
            {
                return aqjb;
            }

            set
            {
                aqjb = value;
            }
        }
        /// <summary>
        /// 洗涤方法
        /// </summary>
        public string Xdff
        {
            get
            {
                return xdff;
            }

            set
            {
                xdff = value;
            }
        }
        /// <summary>
        /// 洗涤方法上装
        /// </summary>
        public string Xdff_sz
        {
            get
            {
                return xdff_sz;
            }

            set
            {
                xdff_sz = value;
            }
        }
        /// <summary>
        /// 洗涤方法下装
        /// </summary>
        public string Xdff_xz
        {
            get
            {
                return xdff_xz;
            }

            set
            {
                xdff_xz = value;
            }
        }
        /// <summary>
        /// 警告语
        /// </summary>
        public string Jgy
        {
            get
            {
                return jgy;
            }

            set
            {
                jgy = value;
            }
        }
        /// <summary>
        /// 注意事项
        /// </summary>
        public string Zysx
        {
            get
            {
                return zysx;
            }

            set
            {
                zysx = value;
            }
        }
        /// <summary>
        /// 使用和贮藏
        /// </summary>
        public string Sycc
        {
            get
            {
                return sycc;
            }

            set
            {
                sycc = value;
            }
        }
        /// <summary>
        /// 注意事项SX
        /// </summary>
        public string Zysx_sx
        {
            get
            {
                return zysx_sx;
            }

            set
            {
                zysx_sx = value;
            }
        }
        /// <summary>
        /// 使用和贮藏SX
        /// </summary>
        public string Sycc_sx
        {
            get
            {
                return sycc_sx;
            }

            set
            {
                sycc_sx = value;
            }
        }
        /// <summary>
        /// 注意事项KUSX
        /// </summary>
        public string Zysx_kusx
        {
            get
            {
                return zysx_kusx;
            }

            set
            {
                zysx_kusx = value;
            }
        }
        /// <summary>
        /// 使用和贮藏KUSX
        /// </summary>
        public string Sycc_kusx
        {
            get
            {
                return sycc_kusx;
            }

            set
            {
                sycc_kusx = value;
            }
        }

        public List<Ico> IcoList
        {
            get
            {
                return icoList;
            }

            set
            {
                icoList = value;
            }
        }

        public List<SxChdmDataContent> SxChdmList
        {
            get
            {
                return sxChdmList;
            }

            set
            {
                sxChdmList = value;
            }
        }

        public List<SphhCmInfo> SphhCmInfo
        {
            get
            {
                return sphhCmInfo;
            }

            set
            {
                sphhCmInfo = value;
            }
        }

        public List<MaterialInfo2> CfList
        {
            get
            {
                return cfList;
            }

            set
            {
                cfList = value;
            }
        }

        public Dictionary<string, int> Cm
        {
            get
            {
                return cm;
            }

            set
            {
                cm = value;
            }
        }
    }
 
}
