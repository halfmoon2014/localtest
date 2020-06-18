<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bigv2.aspx.cs" Inherits="bigv2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding-top: 10px;"><span style="font-size: 18px; font-weight: bold;">裁前验布明细</span></div>
        <table style="table-layout: fixed;" class="blk selfbank" height="1" border="1" cellspacing="0" cellpadding="1" bordercolordark="white" bordercolor="#cccccc" bgcolor="#D4CFC9">
            <tr class="headtitle">
                <td rowspan="3" style="width: 40px">卷号</td>
                <td rowspan="3" style="width: 40px">缸号</td>
                <td rowspan="3" style="width: 40px">批次</td>
                <td rowspan="3" style="width: 40px">供应商<br />
                    分色
                </td>
                <td colspan="4" style="text-align:center" >面料供应商检验
                </td>
                <td colspan="18" style="text-align: center">加工厂检验
                </td>
            </tr>
            <tr>
                <td rowspan="2" style="width: 40px">毛幅宽</td>
                <td rowspan="2" style="width: 40px">有效幅宽</td>
                <td rowspan="2" style="width: 40px">克重</td>
                <td rowspan="2" style="width: 40px">换片率</td>
                <!-- 工厂-->
                <td rowspan="2" style="width: 40px">幅宽</td>
                <td rowspan="2" style="width: 40px">克重</td>
                <td colspan="2" >预缩后</td>
                <td colspan="2" >汽烫缩率</td>
                <td colspan="2" >水洗缩率</td>
                <td rowspan="2" style="width: 40px">换片率</td>
                <td rowspan="2" style="width: 40px">边中色差/级</td>
                <td rowspan="2" style="width: 40px">头尾色差/级</td>
                <td rowspan="2" style="width: 40px">纬斜（%）</td>
                <td rowspan="2" style="width: 40px">纬弧（CM）</td>
                <td rowspan="2" style="width: 40px">循环大小（CM）</td>
                <td rowspan="2" style="width: 40px">松紧边、荷叶边</td>
                <td rowspan="2" style="width: 40px">卷边</td>
                <td rowspan="2" style="width: 40px">疵点扣分位置分布</td>
                <td rowspan="2" style="width: 40px">总扣分</td>
            </tr>
            <tr>
                <td>幅宽</td>
                <td>克重</td>
                <td>经向</td>
                <td>纬向</td>
                <td>经向</td>
                <td>纬向</td>               
            </tr>
            <tr style="background-color: white" class="md2222 rep">
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;
                </td>
                <td>&nbsp;
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;
                </td>
                <td>&nbsp;
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
               
            </tr>
        </table>
        <div style="padding-top: 10px;"><span style="font-size: 18px; font-weight: bold;">裁前验布，根据实际幅宽重新排版汇总表</span></div>
        <table style="table-layout: fixed;" class="blk selfbank" height="1" border="1" cellspacing="0" cellpadding="1" bordercolordark="white" bordercolor="#cccccc" bgcolor="#D4CFC9">
            <tr class="headtitle">
                <td rowspan="2" style="width: 40px">批次</td>
                <td rowspan="2" style="width: 40px">LOT色</td>
                <td rowspan="2" style="width: 40px">毛幅宽
                </td>
                <td rowspan="2" style="width: 120px">幅宽范围汇总</td>
                <td rowspan="2" style="width: 120px">预缩后幅宽范围汇总</td>
                <td rowspan="2" style="width: 120px">平均克重
                </td>
                <td rowspan="2" style="width: 120px">预缩后克重汇总
                </td>
                <td rowspan="2" style="width: 60px">单位
                </td>
                <td rowspan="2" style="width: 60px">加工厂检验数量
                </td>
                <td rowspan="2" style="width: 60px">匹数汇总
                </td>
                <td rowspan="2" style="width: 60px">平均换片率
                </td>
                <td colspan="2" >加工厂汽烫缩率</td>
                <td colspan="2"  >加工厂水洗缩率</td>
                <td colspan="2" >样板缩率</td>
            </tr>
            <tr>
                <td style="width: 60px">经向</td>
                <td style="width: 60px">纬向</td>
                <td style="width: 60px">经向</td>
                <td style="width: 60px">纬向</td>
                <td style="width: 60px">经向</td>
                <td style="width: 60px">纬向</td>
            </tr>
            <tr style="background-color: white" class="gcMDhz rep">
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>

        <div style="padding-top: 10px;"><span style="font-size: 18px; font-weight: bold;">裁前验布重新排版单耗结算</span></div>
        <table style="table-layout: fixed;" class="blk selfbank" height="1" border="1" cellspacing="0" cellpadding="1" bordercolordark="white" bordercolor="#cccccc" bgcolor="#D4CFC9">
            <tr class="headtitle">
                <td  style="width: 40px">批次</td>
                <td  style="width: 40px">LOT色</td>
                <td  style="width: 40px">实际开裁幅宽
                </td>
                <td  style="width: 40px">实际开裁克重</td>
                <td  style="width: 40px">成衣
                    下单数量
                </td>
                <td  style="width: 40px">分批分色开裁量D
                </td>
                <td  style="width: 60px">单位
                </td>
                <td  style="width: 60px">加工厂检验数量
                </td>
                <td  style="width: 60px">匹数汇总
                </td>

                <td  style="width: 40px">平均换片率(%)H
                </td>
                <td  style="width: 60px">单耗C
                </td>
                <td  style="width: 60px">可裁剪件数A=B*(1-H/100)/C</td>
                <td  style="width: 60px">多裁E=A-D</td>
                <td  style="width: 60px">少裁F=D-A
                </td>
                <td  style="width: 60px">需补料
                </td>
                <td  style="width: 60px">实际补量
                </td>
                <td  style="width: 60px">节余面料
                </td>
                <td  style="width: 60px">实际节余
                </td>
                <td  style="width: 60px">工厂多裁数量
                </td>
                <td  style="width: 60px">工厂少裁数量
                </td>
            </tr>
         
            <tr style="background-color: white" class="gcMDhz rep">
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
