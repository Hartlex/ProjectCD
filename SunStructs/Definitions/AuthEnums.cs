using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunStructs.Definitions
{
    public enum PacketResultType
    {
        PACKET_RESULT_SUCCESS,
        PACKET_RESULT_FAIL,
    };
    public enum AuthResultType
    {
        AUTH_RESULT_OK,                      // ÀÎÁõ ¼º°ø
        AUTH_RESULT_INVALID_ACCOUNT,          // id È¤Àº password ¿À·ù
        AUTH_RESULT_SYSTEM_ERROR,             // ½Ã½ºÅÛ Àå¾Ö
        AUTH_RESULT_NOT_EXIST_ACCOUNT,         // Á¸ÀçÇÏÁö ¾Ê´Â °èÁ¤(ÇöÀç »ç¿ëµÇÁö ¾ÊÀ½)
        AUTH_RESULT_INVALID_PASSWORD,         // Àß¸øµÈ ¾ÏÈ£(ÇöÀç »ç¿ëµÇÁö ¾ÊÀ½)
        AUTH_RESULT_NOT_ALLOWED_ACCOUNT,       // Á¢¼ÓÀÌ Çã¿ëµÇÁö ¾ÊÀº °èÁ¤
        AUTH_RESULT_PRE_CONNECT_REMAIN,        // ÀÌÀü Á¢¼ÓÁ¤º¸°¡ ³²¾ÆÀÖÀ½. Àá½ÃÈÄ ´Ù½Ã ½Ãµµ
        AUTH_RESULT_RESTRICT_ADULT,           // ¼ºÀÎ¼­¹ö¿¡ Á¢¼ÓÇÒ ¼ö ¾øÀ½
        AUTH_RESULT_RESTRICT_CROWD,           // ¼­¹ö È¥Àâµµ°¡ ¸¸¶¥ÀÌ¶ó Á¢¼ÓÇÒ ¼ö ¾øÀ½
        AUTH_RESULT_BILLING_EXPIRED,          // ºô¸µ °áÁ¦ ½Ã°£ ¸¸·áµÇ¾úÀ½
        AUTH_RESULT_PROCESS_LOGIN,            // ÀÌ¹Ì ÀÎÁõÁßÀÎ °èÁ¤ÀÌ Á¸Àç
        AUTH_RESULT_ALREADY_LOGIN,            // ÀÌ¹Ì Á¢¼ÓÁß. Àá½ÃÈÄ ´Ù½Ã ½Ãµµ.
        AUTH_RESULT_ACCOUNT_BLOCK,           // ÀÎÁõ ¿¬¼Ó ¿À·ù·Î ÀÎÇÑ °èÁ¤ ºí·Ï »óÅÂ
        AUTH_RESULT_GAME_CHU_INVALID_USN,      // °ÔÀÓÃò ÀÎÁõ ¸ðµâ ½ÇÆÐ
        AUTH_RESULT_INGAMBA_INVALID,         // ·¯½Ã¾Æ ÀÎ°¨¹Ù ¸ðµâ ÀÎÁõ ½ÇÆÐ
        AUTH_RESULT_MAX,
    };
}
