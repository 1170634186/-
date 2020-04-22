using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Shopping.Infrastructure.Util
{
    public class mail
    {
        public string Sendmail(string mails)
        {
            string code = codes();
            MailMessage mailMsg = new MailMessage();//实例化对象
            mailMsg.From = new MailAddress("1170634186@qq.com", "二手交易网");//源邮件地址和发件人
            mailMsg.To.Add(new MailAddress(mails));//收件人地址
            mailMsg.Subject = "用户注册验证码";//发送邮件的标题
            StringBuilder sb = new StringBuilder();
            sb.Append("以下是在注册时获取的邮箱验证码,如非本人,请忽略");
            sb.Append(code);
            mailMsg.Body = sb.ToString();//发送邮件的内容
            //指定smtp服务地址（根据发件人邮箱指定对应SMTP服务器地址）
            SmtpClient client = new SmtpClient();//格式：smtp.126.com  smtp.164.com
            client.Host = "smtp.qq.com";
            //要用587端口
            client.Port = 587;//端口
            //加密
            client.EnableSsl = true;
            //通过用户名和密码验证发件人身份   ???授权码?
            client.Credentials = new NetworkCredential("1170634186@qq.com", "xxxxxxxxxxxxxx"); // 
            //发送邮件
            try
            {
                client.Send(mailMsg);
                return code;
            }
            catch (SmtpException ex)
            {
                return "错误";
            }
            
        }

        public string codes()
        {
            string code="";
            Random r = new Random();
            for(int i = 0; i < 6; i++)
            {
                code += r.Next(0, 9);
            }
            return code;
        }
    }
}
