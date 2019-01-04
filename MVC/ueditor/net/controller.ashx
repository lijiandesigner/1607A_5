<%@ WebHandler Language="C#" Class="UEditorHandler" %>

using System;
using System.Web;
using System.IO;
using System.Collections;
using Newtonsoft.Json;

public class UEditorHandler : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        Handler action = null;
        switch (context.Request["action"])
        {
            case "config":
                action = new ConfigHandler(context);
                break;
            case "uploadimage":
                action = new UploadHandler(context, new UploadConfig()
                {
                    AllowExtensions = Config.GetStringList("imageAllowFiles"),
                    PathFormat = Config.GetString("imagePathFormat"),
                    SizeLimit = Config.GetInt("imageMaxSize"),
                    UploadFieldName = Config.GetString("imageFieldName")
                });
                break;
            case "uploadscrawl":
                action = new UploadHandler(context, new UploadConfig()
                {
                    AllowExtensions = new string[] { ".png" },
                    PathFormat = Config.GetString("scrawlPathFormat"),
                    SizeLimit = Config.GetInt("scrawlMaxSize"),
                    UploadFieldName = Config.GetString("scrawlFieldName"),
                    Base64 = true,
                    Base64Filename = "scrawl.png"
                });
                break;
            case "uploadvideo":
                action = new UploadHandler(context, new UploadConfig()
                {
                    AllowExtensions = Config.GetStringList("videoAllowFiles"),
                    PathFormat = Config.GetString("videoPathFormat"),
                    SizeLimit = Config.GetInt("videoMaxSize"),
                    UploadFieldName = Config.GetString("videoFieldName")
                });
                break;
            case "uploadfile":
                action = new UploadHandler(context, new UploadConfig()
                {
                    AllowExtensions = Config.GetStringList("fileAllowFiles"),
                    PathFormat = Config.GetString("filePathFormat"),
                    SizeLimit = Config.GetInt("fileMaxSize"),
                    UploadFieldName = Config.GetString("fileFieldName")
                });
                break;
            case "listimage":
                action = new ListFileManager(context, Config.GetString("imageManagerListPath"), Config.GetStringList("imageManagerAllowFiles"));
                break;
            case "listfile":
                action = new ListFileManager(context, Config.GetString("fileManagerListPath"), Config.GetStringList("fileManagerAllowFiles"));
                break;
            case "catchimage":
                action = new CrawlerHandler(context);
                break;
            default:
                action = new NotSupportedHandler(context);
                break;
        }
        action.Process();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}

//  ҳ��ʹ��˵��
//  1��  �����д��븴�Ƶ� ͼƬ·������λ��
//  2��  �޸� FID Ϊ ��ID �� form 
//  3��  �޸� FILEID Ϊ ����ͼƬ·�����ı����ID  �����ı����޸�Ϊ ������ type='text' ��Ϊ type='hidden'
//       ��   path  ����Ϊ ueditor��net����ʵ·��
//  4��  <form>�������� method="post" enctype="multipart/form-data" �������� ����ʾ�� 
//       <form id="f1" method="post" enctype="multipart/form-data">
//  5��  ��ҳ���� ���jquery.form.js �ļ� �������� JQUERY.js����

    //<script>
                            //function dd() {
                            //    var fid = "form";
                            //    var fileId = "#txtPhoto";
                            //    var path = "/Content/ueditor/net/";; //����Controller.ashx �Ĵ��·��  �ļ�������� ֻ����upfile�ǲ������޸�

                            //    $(fid).ajaxSubmit({    //��ȡ��ID ִ�� �첽�ύ ajaxSubmit  ע��� id
                            //        url: path+'controller.ashx',
                            //        type: 'post',
                            //        data: { action: 'uploadimage' },
                            //        dataType: 'json',
                            //        success: function (a) {
                            //            if (a.state == "SUCCESS") {
                            //                var imgpath = path + a.url;
                            //                $("#divImg").append('<img src="' + imgpath + '" style="width:100px;height:100px"/>');
                            //                $(fileId).val(imgpath);
                            //            }
                            //            else {
                            //                alert(a.state);
                            //            }
                            //        }
                            //    });
                            //}
    //</script>

    //// �ļ��� �� Ԥ��DIV ������ָ���� form ����
    //        <input type="file" name="upfile" onchange="dd()" />
    //        <div id="divImg"></div>