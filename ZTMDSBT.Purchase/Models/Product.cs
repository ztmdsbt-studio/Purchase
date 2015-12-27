using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using CsQuery;
using CsQuery.ExtensionMethods;
using CsQuery.ExtensionMethods.Internal;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Extensions;
using ZTMDSBT.Purchase.Service;

namespace ZTMDSBT.Purchase.Models
{
  public class Product
  {
    private JObject _content;

    public string ProductId { get; set; }

    public string ProductGroupId { get; set; }

    public string DisplayName { get; set; }

    public string ProductTitle { get; set; }

    public DateTime StartDate { get; set; }

    public bool InStock { get; set; }

    public bool PreOrder { get; set; }

    public int QuantityLimit { get; set; }

    public bool Unlocked { get; set; }

    public bool ShowBuyingTools { get; set; }

    public bool ShowSizeAndFitLink { get; set; }

    public string StyleNumber { get; set; }

    public string ColorNumber { get; set; }

    public List<ProductSku> ProductSkus { get; } = new List<ProductSku>();

    public string Url { get; set; }

    public void GetProductInfo(IList<RestResponseCookie> cookies, string url = null)
    {
      var producUrl = url ?? Url;

      var client = new RestClient("http://store.nike.com");
      var request = Request.ProductInfoByUrl(producUrl);
      var response = client.Execute(request);
      if (response.StatusCode == HttpStatusCode.OK)
      {
        FillProductInfo(response);
      }
    }

    private void FillProductInfo(IRestResponse response)
    {
      CQ dom = response.Content;
      var productData = dom["[type='template-data']"];
      _content = JObject.Parse(productData[0].InnerHTML);
      ProductId = _content["productId"].ToString();
      ProductGroupId = _content["productGroupId"].ToString();
      DisplayName = _content["displayName"].ToString();
      ProductTitle = _content["productTitle"].ToString();
      StartDate =
        new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(double.Parse(_content["startDate"].ToString()));
      InStock = bool.Parse(_content["inStock"].ToString());
      PreOrder = bool.Parse(_content["preOrder"].ToString());
      QuantityLimit = int.Parse(_content["quantityLimit"].ToString());
      Unlocked = bool.Parse(_content["unlocked"].ToString());
      ShowBuyingTools = bool.Parse(_content["showBuyingTools"].ToString());
      ShowSizeAndFitLink = bool.Parse(_content["showSizeAndFitLink"].ToString());
      StyleNumber = _content["styleNumber"].ToString();
      ColorNumber = _content["colorNumber"].ToString();
      Url = _content["url"].ToString();
      _content["skuContainer"]["productSkus"].ForEach(jo =>
      {
        ProductSkus.Add(new ProductSku()
        {
          Product = this,
          Id = jo["id"].ToString(),
          InStock = bool.Parse(jo["inStock"].ToString()),
          DisplaySize = jo["displaySize"].ToString(),
          Sku = jo["sku"].ToString(),
        });
      });
    }
  }
}
//      cookies?.ForEach(c => request.AddCookie(c.Name, c.Value));
//      var cookie =
//        "AnalysisUserId=122.227.101.68.201031451212587306; TBMCookie_3736107480867066708=725528001451183885nlKznowJ72dJNlISOYV7lVLAAjs=; ___utmvm=###########; ___utmva=###aaaa####; ___utmvb=#Z#aaaa    X##O#al#: #t#; NIKE_COMMERCE_CCR=1451212588148; nike_locale=cn/zh_cn; NIKE_COMMERCE_COUNTRY=CN; NIKE_COMMERCE_LANG_LOCALE=zh_CN; neo.swimlane=15; guidU=9a427b8d-e094-4a78-e238-7faba9cb2804; dreams_sample=96; utag_main=_st:1451214389078$ses_id:1451213104710%3Bexp-session; guidS=eac56104-8b42-480f-8018-43be5780f11c; guidSTimestamp=1451212588536|1451212588536; DAPROPS=\"bjs.webGl:1 | bjs.geoLocation:1 | bjs.webSqlDatabase:0 | bjs.indexedDB:1 | bjs.webSockets:1 | bjs.localStorage:1 | bjs.sessionStorage:1 | bjs.webWorkers:1 | bjs.applicationCache:1 | bjs.supportBasicJavaScript:1 | bjs.modifyDom:1 | bjs.modifyCss:1 | bjs.supportEvents:1 | bjs.supportEventListener:1 | bjs.xhr:1 | bjs.supportConsoleLog:1 | bjs.json:1 | bjs.deviceOrientation:0 | bjs.deviceMotion:1 | bjs.touchEvents:0 | bjs.querySelector:1 | bjs.battery:1 | bhtml.canvas:1 | bhtml.video:1 | bhtml.audio:1 | bhtml.svg:1 | bhtml.inlinesvg:1 | bcss.animations:1 | bcss.columns:1 | bcss.transforms:1 | bcss.transitions:1 | idisplayColorDepth:24 | bcookieSupport:1 | sdevicePixelRatio:1 | sdeviceAspectRatio:16 / 9 | bflashCapable:1 | baccessDom:1 | buserMedia:1\"; RES_TRACKINGID=357532769975086; ResonanceSegment=1; RES_SESSIONID=788487231059244; pr_data=0; s_sess=%20s_cc%3Dtrue%3B%20c51%3Dhorizontal%3B%20s_sq%3D%3B; s_pers=%20s_fid%3D40D897D4356FA363-27BCCCD56D48B9D9%7C1514370990319%3B%20c5%3Dnikecom%253Epdp%253EJORDAN%2520SUPERFLY%25204%7C1451214390321%3B%20c6%3Dpdp%253Astandard%7C1451214390322%3B%20c58%3Dno%2520value%7C1451214390326%3B%20l2%3Dno%2520value%7C1451214390328%3B; dreams_session=catching-dreams; s_vi=[CS]v1|2B3FDF97852AB2E1-400003026002C456[CE]; _gscu_207448657=51212594tp5z4h19; _gscs_207448657=51212594z4n80819|pv:1; _gscbrs_207448657=1; _smt_uid=567fbf32.1b0959d0; _jzqa=1.276298344841922620.1451212595.1451212595.1451212595.1; _jzqb=1.2.10.1451212595.1; _jzqc=1; _jzqckmp=1; _qzja=1.1981295844.1451212595090.1451212595090.1451212595090.1451212595090.1451212595090..0.0.1.1; _qzjb=1.1451212595090.1.0.0.0; _qzjc=1; _qzjto=1.1.0";
//      cookie.SplitClean(';').ForEach(c => request.AddParameter(c.Split('=')[0], c.Split('=')[1], ParameterType.Cookie));
//      request.AddCookie("AnalysisUserId", "Vn@4hwoMQ10AAAFivz8AAAFF");
