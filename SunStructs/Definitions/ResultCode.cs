using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunStructs.Definitions
{
	public enum ItemResult
	{
		RC_ITEM_FAILED,
		RC_ITEM_SUCCESS,
		RC_ITEM_INVALIDSTATE,
		RC_ITEM_INVALIDPOS,
		RC_ITEM_EMPTYSLOT,              //< Æ¯Á¤À§Ä¡ÀÇ ½½·ÔÀÌ ºñ¾îÀÖ´Ù.
		RC_ITEM_NOTEXISTITEMATFIELD,    //< ÇÊµå¿¡ ¾ÆÀÌÅÛÀÌ Á¸ÀçÇÏÁö ¾Ê´Â´Ù.
		RC_ITEM_NOINFO,                 //< Code¿¡ ÇØ´çÇÏ´Â ¾ÆÀÌÅÛ Á¤º¸°¡ Á¸ÀçÇÏÁö ¾Ê´Â´Ù.
		RC_ITEM_NOSPACEININVENTORY,     //< ÀÎº¥Åä¸®¿¡ ºó °ø°£ÀÌ ¾ø´Ù.
		RC_ITEM_INVALIDSTATEOFPLAYER,   //< ÇÃ·¹ÀÌ¾î »óÅÂ°¡ ÀÌ»óÇÏ´Ù
		RC_ITEM_INVALIDPOSFORDROPITEM,  //< µå¶øÇÒ ¾ÆÀÌÅÛÀÇ À§Ä¡°¡ Àß¸øµÇ¾ú´Ù.
		RC_ITEM_UNKNOWNERROR,           //< ¾Ë¼ö ¾ø´Â ¿¡·¯, Å¬¶óÀÌ¾ðÆ®¿¡¼­ÀÇ Àß¸øµÈ µ¥ÀÌÅÍ È¤Àº ÇØÅ·¿¡ ÀÇÇØ µ¥ÀÌÅÍ Å©·¢
		RC_ITEM_DBP_ASYNC,              //< DBP·ÎºÎÅÍ ºñµ¿±âÀûÀ¸·Î ½Ã¸®¾ó ¹ß±Þ ¿äÃ» »óÅÂ
		RC_ITEM_COOLTIME_ERROR,         //< ÄðÅ¸ÀÓÀÌ ³¡³ªÁö ¾Ê¾Ò´Ù.

		//< Combine
		RC_ITEM_ITEMCODENOTEQUAL,       //< ¾ÆÀÌÅÛ ÄÚµå°¡ ´Ù¸£´Ù.

		//< use
		RC_ITEM_ISNOTWASTEITEM,                 //< ¼Ò¸ð¼º ¾ÆÀÌÅÛÀÌ ¾Æ´Ï´Ù.
		RC_ITEM_PORTION_USE_LIMIT,              //< °æÀïÇåÆÃ¿¡¼­ Æ÷¼Ç»ç¿ë °³¼ö Á¦ÇÑÀÌ ÀÖ´Ù.
		RC_ITEM_CAN_USE_FIELD,                  //< ÇÊµå¿¡¼­¸¸ »ç¿ëÇÒ ¼ö ÀÖ´Ù.
		RC_ITEM_INVALID_TYPE,                   //< ÇØ´ç ±â´ÉÀ» ÀÌ¿ëÇÒ ¼ö ÀÖ´Â ¾ÆÀÌÅÛ Á¾·ù°¡ ¾Æ´Ï´Ù.
		RC_ITEM_FIELD_IS_NULL,
		RC_ITEM_UNABLE_FUNCTION_FOR_CUR_ZONE,   //< ÇöÀç Áö¿ª¿¡¼­´Â »ç¿ëÇÒ ¼ö ¾ø´Â ±â´ÉÀÔ´Ï´Ù.
		RC_ITEM_CANNOT_USE,                     // ¾ÆÀÌÅÛÀ» »ç¿ëÇÒ ¼ö ¾ø½À´Ï´Ù.
		RC_ITEM_CANNOT_MOVE_TO_THE_AREA,        //< ÇØ´çÀ§Ä¡·Î ÀÌµ¿ÇÒ ¼ö ¾ø´Ù.
		RC_ITEM_CANNOT_LEARN_SKILL,             //< ½ºÅ³À» ½Àµæ ÇÒ ¼ö ¾ø½À´Ï´Ù.
		RC_ITEM_CANNOT_SKILL_ACTION,            //< ½ºÅ³À» ½ÃÀü ÇÒ ¼ö ¾ø½À´Ï´Ù. 816, 
		RC_ITEM_CANNOT_FIND_PLAYER_TO_MOVE,     //< ÀÌµ¿½ÃÅ°·Á´Â ÇÃ·¹ÀÌ¾î¸¦ Ã£À» ¼ö ¾ø´Ù.
		RC_ITEM_NOT_STORE_COORD,                //< ÁÂÇ¥°¡ ÀúÀåµÇ¾î ÀÖÁö ¾Ê´Ù.
		RC_ITEM_ALREADY_STORE_COORD,            //< ÀÌ¹Ì ÁÂÇ¥°¡ ÀúÀåµÇ¾î ÀÖ´Ù.
		RC_ITEM_CANNOT_STORE_COORD_AT_THIS_AREA,//< ÇØ´çÀ§Ä¡¿¡¼­´Â ÁÂÇ¥¸¦ ÀúÀåÇÒ ¼ö ¾ø´Ù.	
		RC_ITEM_CANNOT_CREATE_TOTEMNPC,  
		//< TotemNPC¸¦ »ý¼ºÇÒ ¼ö ¾ø´Ù.
		RC_ITEM_CANNOT_USE_ALREADY_APPLY_HIGHRANK_BUFF, //< ÀÌ¹Ì »óÀ§·©Å©ÀÇ ¹öÇÁ°¡ °É·ÁÀÖ±â¶§¹®¿¡ »ç¿ëÇÒ ¼ö ¾ø´Ù.

		//< sell
		RC_ITEM_INVALIDSHOPLISTID,      //< dwShopListID°¡ Àß¸øµÇ¾ú´Ù.
		RC_ITEM_OUTOFSHOPITEMINDEX,     //< shop¿¡¼­ ÆÇ¸ÅÇÏ´Â ¾ÆÀÌÅÛ ÀÎµ¦½º°¡ ¾Æ´Ï´Ù.
		RC_ITEM_HAVENOTMONEY,           //< µ·ÀÌ ¾ø´Ù.

		//< buy
		RC_ITEM_ISNOTEMPTYSLOT,         //< ºó ½½·ÔÀÌ ¾ø´Ù ²Ë Ã¡´Ù.
		RC_ITEM_HAVENOTSPACE,           //< °ø°£ÀÌ ºÎÁ·ÇÏ´Ù.
		RC_ITEM_INVALIDVALUE,           //< Àß¸øµÈ °ªÀÌ ¿Ô´Ù.

		//< pick
		RC_ITEM_OVER_PLAYING_TIME,
		RC_ITEM_DONOT_HAVE_OWNERSHIP,       //< ¾ÆÀÌÅÛ¿¡ ´ëÇÑ ¼ÒÀ¯±ÇÀÌ ¾ø´Ù.
		RC_ITEM_UNPICKABLE_TYPE,            //< ÁÖÀ» ¼ö ¾ø´Â ¾ÆÀÌÅÛ Å¸ÀÔÀÌ´Ù. 
		RC_ITEM_CANT_PICKABLE_BY_LENGTH,    //< Á¤»óÀûÀ¸·Î ÁÖÀ» ¼ö ¾ø´Â °Å¸®´Ù. ÇÙ?
		RC_ITEM_DEAD_OWNER,                 //< ¾ÆÀÌÅÛÀÇ ¼ÒÀ¯±ÇÀÚ°¡ Á×¾î ÀÖ´Ù.

		//</.....
		//< drop
		RC_ITEM_ERRORDROPMONEY,

		//< enchant ¼º°ø
		RC_ITEM_ENCHANT_SUCCESS,
		//< enchant ½ÇÆÐ
		RC_ITEM_ENCHANT_FAILED,
		RC_ITEM_ENCHANT_DOWN_FAILED,
		RC_ITEM_ENCHANT_CRACK_FAILED,
		RC_ITEM_ENCHANT_HAVENOTMETERIALS,
		RC_ITEM_ENCHANT_INVALID_ITEMLEVEL,          //< ¾ÆÀÌÅÛ ·¹º§¿¡ ´ëÇÑ ÀÎÃ¾Æ® ÇÊ¿ä Àç·á Á¤º¸°¡ ¾ø´Ù. (Áï, ¾ÆÀÌÅÛ ·¹º§ÀÌ Àß¸øµÇ¾ú´Ù. )
		RC_ITEM_ENCHANT_INVALID_RATE_INDEX,         //< Àß¸øµÈ ¼º°øÈ®·ü ÀÎµ¦½º °ªÀÌ´Ù.
		RC_ITEM_ENCHANT_FAILED_AND_ENCHNAT_DOWN,    //< ÀÎÃ¾Æ®°¡ ½ÇÆÐÇÏ¿´°í, ÀÎÃ¾Æ® °ªÀÌ ´Ù¿î µÇ¾ú½À´Ï´Ù.
		RC_ITEM_ENCHANT_FAILED_AND_DESTROY,         //< ÀÎÃ¾Æ®°¡ ½ÇÆÐÇÏ¿´°í ¾ÆÀÌÅÛÀÌ ¼Ò¸êµÇ¾ú½À´Ï´Ù. [0815¿¡¼­ »ç¿ë ¾ÈµÊ.]

		//< rankup
		RC_ITEM_INVALID_CONDITION,                  //< Ã¼Å© Á¶°Ç¿¡ ¸ÂÁö ¾Ê´Â´Ù.
		RC_ITEM_CANNT_RANKUP_ITEM,
		RC_ITEM_NO_MORE_RANK,
		RC_ITEM_INSUFFICIENT_MONEY,                 //< µ·ÀÌ ºÎÁ·ÇÏ´Ù.		
		RC_ITEM_RANKUP_FAILED_AND_DESTROY,          //< ·©Å©¾÷ÀÌ ½ÇÆÐ ÇÏ¿© ¾ÆÀÌÅÛÀÌ ¼Ò¸êµÇ¾ú½À´Ï´Ù.

		//< socket
		RC_ITEM_FULLSOCKET,             //< ¼ÒÄÏÀÌ ²Ë Ã¡´Ù.

		//< extract socket
		RC_ITEM_EXTRACTSOCKET_SUCCESS,
		RC_ITEM_EXTRACTSOCKET_FAILED,

		RC_ITEM_UNUSABLE_FUNCTION,      //< ÇöÀç »ç¿ëÇÒ ¼ö ¾ø´Â ±â´ÉÀÔ´Ï´Ù.
		RC_ITEM_INVALID_VALUE,          //< Àß¸øµÈ °ªÀÌ´Ù.
		RC_ITEM_CANNNOT_DROPSTATE,      //< dropÇÒ ¼ö ¾ø´Â »óÅÂÀÔ´Ï´Ù.
		RC_ITEM_NOTEXIST_ITEM,          //< ¾ÆÀÌÅÛÀÌ Á¸ÀçÇÏÁö ¾Ê´Â´Ù.

		RC_ITEM_CANNOT_SELL_ITEM,       //< ÆÇ¸Å°¡ ºÒ°¡´ÉÇÑ ¾ÆÀÌÅÛÀÔ´Ï´Ù.
		RC_ITEM_CANNOT_TRADE_ITEM,      //< °Å·¡°¡ ºÒ°¡´ÉÇÑ ¾ÆÀÌÅÛÀÔ´Ï´Ù.
		RC_ITEM_CANNOT_DROP_ITEM,       //< µå¶øÀÌ ºÒ°¡´ÉÇÑ ¾ÆÀÌÅÛÀÔ´Ï´Ù.
		RC_ITEM_CANNOT_EXCHANGE_ITEM,   //< ±³È¯ÇÒ ¼ö ¾ø´Â ¾ÆÀÌÅÛÀÔ´Ï´Ù.
		RC_ITEM_CANNOT_MOVE_OTHER_SLOT_ITEM,    //< ´Ù¸¥ ½½·ÔÀ¸·Î ÀÌµ¿ÇÒ ¼ö ¾ø´Â ¾ÆÀÌÅÛÀÔ´Ï´Ù.
		RC_ITEM_CANNOT_DESTROY_ITEM,    //< ÆÄ±«(delete_syn)ÇÒ ¼ö ¾ø´Â ¾ÆÀÌÅÛÀÔ´Ï´Ù.
		RC_ITEM_CANNOT_PICKUP_OBSERVER, //< Åõ¸í»óÅÂ¿¡¼­´Â ¾ÆÀÌÅÛÀ» ÁÖ¿ï ¼ö ¾ø´Ù.
										//< Compose
		RC_ITEM_COMPOSE_SUCCESS,
		RC_ITEM_COMPOSE_FAILED,

		//< Crystalize
		RC_ITEM_CRYSTALIZE_SUCCESS,
		RC_ITEM_CRYSTALIZE_FAILED,

		RC_ITEM_UNABLE_FUNCTION_FOR_CURR_LEVEL,     //< ÇöÀç ·¹º§¿¡¼­ ÀÌ¿ëÇÒ ¼ö ¾ø´Â ±â´ÉÀÔ´Ï´Ù.

		// ³»±¸µµ, ¼ö¸®
		RC_ITEM_DONT_NEED_TO_REPAIR,                //< ¼ö¸®ÇÒ ÇÊ¿ä ¾øÀ½
		RC_ITEM_CANNOT_REPAIR_ITEM,                 //< ¼ö¸®°¡ ºÒ°¡´ÉÇÑ ¾ÆÀÌÅÛÀÔ´Ï´Ù.

		RC_ITEM_COMPOSE_INVALID_LOCATION,           //< Á¶ÇÕÇÒ ¼ö ¾ø´Â ¸ÊÀÔ´Ï´Ù.
		RC_ITEM_COMPOSE_LIMIT_CLASS,                //< Á¶ÇÕÇÒ ¼ö ¾ø´Â Å¬·¡½ºÀÔ´Ï´Ù.

		RC_ITEM_UNABLE_FUNCTION_FOR_CHAOSTATE,      //< Ä«¿À»óÅÂ¿¡¼­´Â ÀÌ¿ëÇÒ ¼ö ¾ø´Â ±â´ÉÀÌ´Ù.
		RC_ITEM_CANNOT_USE_QUEST_ACCEPT_ITEM,       //< Äù½ºÆ® ¼ö¶ô ¾ÆÀÌÅÛÀ» »ç¿ëÇÒ ¼ö ¾ø½À´Ï´Ù.

		RC_ITEM_CANNOT_RANKUP_ELITE,                //< ¿¤¸®Æ® ¾ÆÀÌÅÛ ·©Å©¾÷ ºÒ°¡
		RC_ITEM_CANNOT_CRYSTALIZE_ELITE,            //< ¿¤¸®Æ® ¾ÆÀÌÅÛ °áÁ¤È­ ºÒ°¡
		RC_ITEM_CANNOT_RANKUP_UNIQUE,               //< À¯´ÏÅ© ¾ÆÀÌÅÛ ·©Å©¾÷ ºÒ°¡
		RC_ITEM_CANNOT_CRYSTALIZE_UNIQUE,           //< À¯´ÏÅ© ¾ÆÀÌÅÛ °áÁ¤È­ ºÒ°¡

		RC_ITEM_UNABLE_FUNCTION_FOR_TRANSFORMATION, //< º¯½Å»óÅÂ¿¡¼­´Â ÀÌ¿ëÇÒ ¼ö ¾ø´Â ±â´ÉÀÌ´Ù.

		RC_ITEM_CANNOT_DELETE_FOR_SHORT_COUNT,      //< °³¼öºÎÁ·À¸·Î »èÁ¦ÇÒ ¼ö ¾ø´Ù.
		RC_ITEM_LENGTH_CANNOT_USE_NPC,              //< NPC¸¦ ÀÌ¿ëÇÒ ¼ö ¾ø´Â °Å¸®.
		RC_ITEM_DBG_WRONG_PACKET,                   //< Àß¸øµÈ ÆÐÅ¶ ¼ö½Å	

		RC_ITEM_CANNOT_ADD_EXTRAINVENTORY,          //< ´õÀÌ»ó À¯·áÈ­ ÀÎº¥Åä¸®¸¦ Ãß°¡ÇÒ ¼ö ¾ø´Ù.
		RC_ITEM_CANNOT_DO_THIS_FOR_CHARGEITEM,      //< À¯·áÈ­ ¾ÆÀÌÅÛ¿¡ ´ëÇØ ÀÌ ±â´ÉÀ» ÀÌ¿ëÇÒ ¼ö ¾ø½À´Ï´Ù.
		RC_ITEM_DONT_EXIST_TO_REPAIR,               //< ¼ö¸®ÇÒ ¾ÆÀÌÅÛÀÌ ¾ø½À´Ï´Ù.

		//¼Ò¸êÀÇ ·é
		RC_ITEM_NOT_INVENTORY,                      //< ÀÎº¥Åä¸®°¡ ¾Æ´Ñ ½½·Ô¿¡ Á¸ÀçÇÏ´Â ¾ÆÀÌÅÛÀÔ´Ï´Ù.
		RC_ITEM_INVALID_SOCKET_NUM,                 //< ¼ÒÄÏ¿É¼Ç »èÁ¦½Ã Àß¸øµÈ ¼ÒÄÏ³Ñ¹ö ÀÔ´Ï´Ù.
		RC_ITEM_SOCKET_HAS_NOT_OPTION,              //< ¼ÒÄÏ¿É¼ÇÀÌ ¾ø´Â ¾ÆÀÌÅÛÀÇ ¼ÒÄÏÀ» »èÁ¦ ÇÏ·Á°í ÇÕ´Ï´Ù.
		RC_ITEM_SOCKET_DIFFERENT_LEVEL,             //< »ó,ÇÏ±Þ·éÀÌ ´Ù¸¥ ¼ÒÄÏ ¿É¼ÇÀ» »èÁ¦ÇÒ ¼ö ¾ø½À´Ï´Ù.		
		RC_ITEM_SOKET_NOT_RUNE_ITEM,                //< »ç¿ë ¾ÆÀÌÅÛÀÌ '¼Ò¸êÀÇ ·é'ÀÌ ¾Æ´Ï´Ù.

		RC_ITEM_ISNOT_PARTY_MEMBER,                 //< ÆÄÆ¼ ¸â¹öÀÏ ¶§¸¸ »ç¿ëÇÒ ¼ö ÀÖ´Â ±â´ÉÀÌ´Ù.

		RC_ITEM_NOT_MIXTURE,                        //< ±â´ÉÀ» »ç¿ëÇÒ ¼ö ¾ø´Â ¾ÆÀÌÅÛÀÌ´Ù.(Enchant, Rankup µîµî...)

		//ÃÊ±âÈ­ ¾ÆÀÌÅÛ
		RC_ITEM_LESS_FOR_USE,                       //< ÇØ´ç ¾ÆÀÌÅÛÀÌ ¸ðÀÚ¶ó´Ù.
		RC_ITEM_NOT_UNEQUIP_ALL,                    //< Àåºñ¸¦ ¸ðµÎ ÇØÁ¦ÇÏÁö ¾ÊÀº »óÅÂÀÌ´Ù.
		RC_ITEM_NOT_MORE_DECREASE,                  //< ´õ ÀÌ»ó ½ºÅÈÀ» °¨¼ÒÇÒ ¼ö ¾ø´Ù.
		RC_ITEM_CANNOT_USE_MULTI_ALL_ITEM,          //< ¿Ã½ºÅÝ ÃÊ±âÈ­ ¾ÆÀÌÅÛÀº º¹¼ö·Î »ç¿ëÇÒ ¼ö ¾ø´Ù.

		//¸ó½ºÅÍ ¼ÒÈ¯ ¾ÆÀÌÅÛ
		RC_ITEM_MONSTER_SUMMON_FAILED,              //< ¸ó½ºÅÍ ¼ÒÈ¯ ¾ÆÀÌÅÛÀ» »ç¿ëÀº ¼º°øÇßÁö¸¸ È®·ü·Î ÀÎÇØ ½ÇÆÐ

		RC_ITEM_WAREHOUSE_NEED_PASSWORD,            //< Ã¢°í ºñ¹ø ÇÊ¿äÇÕ´Ï´Ù.
		RC_ITEM_INVENTORY_NEED_PASSWORD,            //< ÀÎº¥Åä¸® ºñ¹ø ÇÊ¿äÇÕ´Ï´Ù.
		RC_ITEM_INVENTORY_INVALID_PASSWORD,         //< Àß¸øµÈ ºñ¹øÀÔ´Ï´Ù.
		RC_ITEM_INVENTORY_ALREADY_TRANSACTION,      //< ´Ù¸¥ ºñ¹ø°ü·Ã Ã³¸®ÁßÀÔ´Ï´Ù.
		RC_ITEM_INVENTORY_PWD_SETTING_FLOW_VIOLATION, //< ºñ¹ø ¼³Á¤°ü·Ã ÇÃ·Î¿ì¸¦ À§¹ÝÇß½À´Ï´Ù.
		RC_ITEM_INVENTORY_INVALID_PACKET,

		RC_ITEM_CANNOT_MOVE_WAREHOUSE_ITEM,         //< Ã¢°í·Î ÀÌµ¿ÇÒ ¼ö ¾ø´Â ¾ÆÀÌÅÛÀÔ´Ï´Ù.		

		RC_ITEM_CANNOT_RANKDOWN_ELITE,              //< ¿¤¸®Æ® ¾ÆÀÌÅÛÀº ·©Å© ÇÏÇâ ºÒ°¡
		RC_ITEM_CANNOT_RANKDOWN_UNIQUE,             //< À¯´ÏÅ© ¾ÆÀÌÅÛÀº ·©Å© ÇÏÇâ ºÒ°¡
		RC_ITEM_NOT_RANK_DOWN_TO_E_RANK_ITEM,       //< E·©Å© ¾ÆÀÌÅÛÀº ·©Å©¸¦ ÇÏÇâÇÒ ¼ö ¾ø½À´Ï´Ù.

		RC_ITEM_CANNOT_EXTEND_CASH_SLOT,            //< ´õÀÌ»ó À¯·áÈ­ ÀåÂø½½·ÔÀ» Ãß°¡ÇÒ ¼ö ¾ø´Ù.
		RC_ITEM_CANNOT_EXTEND_DATE,                 //< ±â°£À» ¿¬ÀåÇÒ ¼ö ¾ø´Â ¾ÆÀÌÅÛÀÌ´Ù.
		RC_ITEM_CANNOT_RANKUP_LIMITED,              //< ¸®¹ÌÆ¼µå ¾ÆÀÌÅÛÀº ·©Å©¾÷ ºÒ°¡.
		RC_ITEM_CANNOT_REPAIR_MAX_DURA_TWO_OVER,    //< ÃÖ´ë ³»±¸µµ 2ÀÌÇÏ¿¡¼­¸¸ »ç¿ë °¡´É
		RC_ITEM_NOT_LIMITED_ITEM,                   //< ¸®¹ÌÆ¼µå ¾ÆÀÌÅÛÀÌ ¾Æ´Ô
		RC_ITEM_OVER_REPAIR_COUNT,                  //< ¼ö¸® °¡´É È½¼ö ³ÑÀ½
		RC_ITEM_CAN_NOT_EQUIP,                      //< ÀåºñÇÒ ¼ö ¾ø´Â ¾ÆÀÌÅÛ
		RC_ITEM_CANNOT_RANKUP_FATE,                 //< Fate ¾ÆÀÌÅÛÀº ·©Å©¾÷ ºÒ°¡.
		RC_ITEM_NOT_FATE_ITEM,                      //< Fate ¾ÆÀÌÅÛ ¾Æ´Ô.
		RC_ITEM_ALREADY_IDENTYFIED_FATE_ITEM,       //< ÀÌ¹Ì °¨Á¤µÈ Fate ¾ÆÀÌÅÛ
		RC_ITEM_WIN_PRIZE_INFINITY_ITEM,            //< NOTE: f110428.5L, removed don't use anymore since 1102, ¹«Á¦ÇÑ ¾ÆÀÌÅÛ¿¡ ´çÃ·µÊ(¼­¹ö¸¸»ç¿ë)
		RC_ITEM_NOT_IDENTYFIED_FATE_ITEM,           //< ÀÌ¹Ì °¨Á¤µÈ Fate ¾ÆÀÌÅÛ
		RC_ITEM_NOT_EXIST,                          //< ¾ÆÀÌÅÛÀÌ Á¸Àç ÇÏÁö ¾Ê½À´Ï´Ù.		

		RC_ITEM_EVENT_SUCCESS,
		RC_ITEM_EVENT_FAILED,
		RC_ITEM_EVENT_ALREADY_ANOTHER_TRANSACTION,      //< [ÀÌº¥Æ®] ÀÌ¹Ì ´Ù¸¥ ¸í·ÉÀÌ ¼öÇàÁßÀÔ´Ï´Ù. Àá½ÃÈÄ ´Ù½Ã ½ÃµµÇÏ¼¼¿ä.
		RC_ITEM_EVENT_CANNOT_MOVE_TO_INVENTORY,         //< [ÀÌº¥Æ®] Can't Move EventInven->Inven
		RC_ITEM_IMPOSSIBLE_PERIOD_EXTEND,               //<  ±â°£ ¿¬Àå ºÒ°¡´É ¾ÆÀÌÅÛ
		RC_ITEM_ALREADY_REGISTER_AC_ITEM,               //< ÀÌ¹Ì µî·ÏµÈ AC ¾ÆÀÌÅÛ

		RC_ITEM_SUMMON_SUMMON_SUCCESS,                  // ¼ÒÈ¯ ¼º°ø
		RC_ITEM_SUMMON_RETURN_SUCCESS,                  // ÇØÁ¦ ¼º°ø		
		RC_ITEM_SUMMON_ALREADY_SUMMONED,                // ÀÌ¹Ì ´Ù¸¥ ÆêÀÌ ¼ÒÈ¯ µÇ¾î ÀÖ¾î ½ÇÆÐ
		RC_ITEM_SUMMON_NOT_PET_ITEM,                    // Æê ¾ÆÀÌÅÛÀÌ ¾Æ´Ô
		RC_ITEM_SUMMON_NOT_SUMMONED_PET,                // ¼ÒÈ¯µÈ ÆêÀÌ ¾ø´Âµ¥ RETURN ÇÏ·Á°í ÇÔ
		RC_ITEM_SUMMON_MISMATCH_PET_ITEM,               // ¼ÒÈ¯µÈ ÆêÀÌ¶û ÇØÁ¦ÇÏ·Á´Â ¾ÆÀÌÅÛÀÌ ¼­·Î ´Ù¸§.	
		RC_ITEM_CAN_NOT_SUMMON_FULLNESS_ZERO,           // Æ÷¸¸°¨ÀÌ 0 ÀÌ¾î¼­ ¼ÒÈ¯ ºÒ°¡
		RC_ITEM_NOT_SUMMONED_PET,                       // ¼ÒÈ¯µÈ ÆêÀÌ ¾øÀ½

		//±æµå Ã¢°í
		RC_ITEM_GUILDWAREHOUSE_USENOT_SLOT_BY_GRADE,    // ±æµå µî±ÞÀÌ ³·¾Æ »ç¿ëÇÒ ¼ö ¾ø´Â ½½·Ô
		RC_ITEM_GUILDWAREHOUSE_USENOT_SLOT_BY_CASHITEM, //Ä³½¬ÅÛÀÌ ¾ø¾î¼­ »ç¿ëÇÒ ¼ö ¾ø´Â ½½·Ô
		RC_ITEM_GUILDWAREHOUSE_NOEN_OUT_RIGHT,          //±æµå Ãâ°í¸¦ ÇÒ ±ÇÇÑÀÌ ¾ø´Ù.
		RC_ITEM_GUILDWAREHOUSE_OPEN_USENOT_CASHITEM,    //±æµå Ã¢°í°¡ ¿­·ÁÀÖ´Â »óÅÂ¿¡¼­´Â È®ÀåÀÚÀç¸¦ ÀÌ¿ëÇÒ¼ö ¾ø´Ù.
		RC_ITEM_GUILDWAREHOUSE_NONE_USENOT_CASHITEM,    //¼Ò¼ÓµÈ ±æµå°¡ ¾ø¾î¼­ ±æµå Ã¢°í È®Àå ¾ÆÀÌÅÛÀ» »ç¿ëÇÒ ¼ö ¾ø½À´Ï´Ù.
		RC_ITEM_GUILDWAREHOUSE_NONE_USE_RIGHT,          //±æµå Ã¢°í È®ÀåÀÚÀç Ä³½¬ÅÛÀ» »ç¿ëÇÒ ±ÇÇÑÀÌ ¾ø´Ù.
														//__NA_1247_POSSESSION_ITEM
		RC_ITEM_GUILDWAREHOUSE_UNABLE_POSSESSION_ITEM,  // ±Í¼ÓµÈ ¾ÆÀÌÅÛÀº ±æµåÃ¢°í¿¡ ¿Å±æ ¼ö ¾ø´Ù.
														//__NA_000968_ETHER_EMISSION_DEVICE
		RC_ITEM_ETHER_DEVICE_USE_ONLY_TO_WEAPON,        // ¿¡Å×¸£ ¹æÃâÀåÄ¡´Â ¹«±â¿¡¸¸ ÀåÂø °¡´É
		RC_ITEM_ALREADY_EQUIP_ETHER_DEVICE,             // ¿¡Å×¸£ ¹æÃâÀåÄ¡°¡ ÀÌ¹Ì ÀåÂø µÇ¾î ÀÖÀ½
		RC_ITEM_NOT_EQUIP_ETHER_DEVICE,                 // ¿¡Å×¸£ ¹æÃâÀåÄ¡°¡ ÀåÂø µÇ¾îÀÖÁö ¾ÊÀ½
		RC_ITEM_ALREADY_CHARGE_ETHER_BULLET,            // ¿¡Å×¸£ ÃÑ¾ËÀÌ ÀÌ¹Ì ÀåÀü µÇ¾î ÀÖÀ½
														// LOTTO
		RC_ITEM_LOTTO_OPEN_SUCCESS,                     // ¿ÀÇÂ ¼º°ø
		RC_ITEM_LOTTO_OPEN_FAIL,                        // ¿ÀÇÂ ½ÇÆÐ
		RC_ITEM_LOTTO_IDENTITY_FAIL,                    // ÀÎÁõ ½ÇÆÐ
		RC_ITEM_LOTTO_IDENTITY_SUCCESS,                 // ÀÎÁõ ¼º°ø
		RC_ITEM_LOTTO_ALREADY_IDENTYFIED_LOTTO_ITEM,    // ÀÌ¹Ì ÀÎÁõµÇ¾îÀÖ´Ù.
		RC_ITEM_LOTTO_NEED_IDENTYFY_LOTTO_ITEM,         // ÀÎÁõÀÌ ÇÊ¿äÇÏ´Ù.
		RC_ITEM_LOTTO_NEED_EMPTY_SLOT,                  // ½½·ÔÀÌ ºÎÁ·ÇÏ´Ù.
		RC_ITEM_LOTTO_NOLOTTOITEM,                      // ·Î¶Ç ¾ÆÀÌÅÛÀÌ ¾Æ´Ï´Ù.
		RC_ITEM_LOTTO_INVALID_LOTTOSCRIPT_INDEX,        // ½ºÅ©¸³Æ® ÀÎµ¦½º°¡ Àß¸øµÇ¾ú´Ù.
		RC_ITEM_LOTTO_INVALID_STATE,                    // ÀÌ»óÇÑ »óÅÂÀÌ´Ù.
		RC_ITEM_LOTTO_NEED_OPEN_STATE,                  // ¿­·ÁÀÖ¾î¾ß ÇÑ´Ù.
		RC_ITEM_LOTTO_ALREADY_OPENED_LOTTO_ITEM,        // ÀÌ¹Ì ¿­·ÁÀÖ´Ù.
		RC_ITEM_LOTTO_CONCRETIZE_SUCCESS,               // ½ÇÃ¼È­ ¼º°ø
		RC_ITEM_LOTTO_CONCRETIZE_FAIL,                  // ½ÇÃ¼È­ ½ÇÆÐ
		RC_ITEM_PANDORABOX_CLOSE_SUCCESS,               // ÆÇµµ¶ó»óÀÚ ´Ý±â ¼º°ø
		RC_ITEM_PANDORABOX_CLOSE_FAIL,                  // ÆÇµµ¶ó»óÀÚ ´Ý±â ½ÇÆÐ

		RC_ITEM_WINDOW_ALREADY_OENDEDSTATE,             // ÀÌ¹Ì À©µµ¿ì°¡ ¿­·ÁÀÖ´Ù.
		RC_ITEM_NOTEXIST_SUMMON_MONSTERINFO,            // ¼­¸Õ Á¤º¸°¡ ¾ø½À´Ï´Ù.
		RC_ITEM_CANNOT_USE_PET_NAME,                    // »ç¿ëÇÒ ¼ö ¾ø´Â Æê ÀÌ¸§(¿å¼³, À½¶õ µî)
		RC_ITEM_CAN_NOT_ACTIVE_ETHER_BULLET,            // ¿¡Å×¸£ ÅºÈ¯À» È°¼ºÈ­ ÇÒ ¼ö ¾ø´Ù
		RC_ITEM_CAN_NOT_INACTIVE_ETHER_BULLET,          // ¿¡Å×¸£ ÅºÈ¯À» ºñÈ°¼ºÈ­ ÇÒ ¼ö ¾ø´Ù
		RC_ITEM_CANT_EQUIP_WEAPON,          //< °ø°Ý¹«±â ÀåÂøÇÒ ¼ö ¾ø½À´Ï´Ù.
		RC_ITEM_CAN_USE_ONLY_CHAO,                      //< 903 Ä«¿À À¯Àú¸¸ »ç¿ëÇÒ ¼ö ÀÖ´Ù.(ÇÁ¸®Ä«¿À Æ÷ÇÔ)
		RC_ITEM_CANNOT_USE_PLAYER_LEVEL,                //< 904 »ç¿ë °¡´ÉÇÑ ·¹º§ÀÌ ¾Æ´Ô __CN_1299_WASTE_ITEM_LEVEL_LIMITE_CHECK
		RC_ITEM_ALREADY_FIREUP_ITEM_SAME_TYPE,          //< 903 ÀÌ¹Ì °°Àº Å¸ÀÔÀÇ ¾ÆÀÌÅÛÀÌ È°¼ºÈ­ µÇ¾îÀÖ´Ù.
														//__NA1390_1391_090915_RIDING_SYSTEM_ITEM_PART__
		RC_ITEM_ALREADY_EXIST,                          //< ÇØ´ç ½½·Ô¿¡ ¾ÆÀÌÅÛÀÌ ÀÌ¹Ì Á¸ÀçÇÑ´Ù.
														//RC_ITEM_CAN_NOT_EQUIP <À§¿¡¼­ ¼±¾ð - ÀåºñÇÒ ¼ö ¾ø´Â ¾ÆÀÌÅÛ
		RC_ITEM_ALREADY_TIME_EXPIRED,                   //< ÀÌ¹Ì ¸¸·áµÈ ¾ÆÀÌÅÛÀÔ´Ï´Ù.

		// (090919) (ÇöÀç ¹ÌÀû¿ë ÄÚµå) __NA_001358_ENCHANT_UNIFICATION
		RC_ITEM_INVALID_ENCHANT_LEVEL,                  //< À¯È¿ÇÏÁö ¾ÊÀº ÀÎÃ¾Æ® ·¹º§
		RC_ITEM_ALREADY_USE_CHARWAYPOINT,               //< ·é½ºÅæ ¾ÆÀÌÅÛÀÌ ÀÌ¹Ì »ç¿ëÁß ÀÔ´Ï´Ù.
														//_NA000109_100427_ITEM_CUSTOMIZING_CONTENTS_
		RC_ITEM_ALREADY_EXTRACTED_TO_ETHERIA,           //< ÀÌ¹Ì ¿¡Å×¸®¾Æ°¡ ÃßÃâµÈ ÀåºñÀÔ´Ï´Ù.
		RC_ITEM_CANT_EXTRACT_TO_ETHERIA,                //< ÀÌ ¾ÆÀÌÅÛÀº ¿¡Å×¸®¾Æ ÃßÃâÀÌ ºÒ°¡´ÉÇÕ´Ï´Ù.
		RC_ITEM_CANT_COMBINED_WITH_ITEM,                //< ÇØ´ç ¾ÆÀÌÅÛÀº °áÇÕÇÒ ¼ö ¾ø½À´Ï´Ù.
		RC_ITEM_CANT_COMBINED_WITH_DIFFERENT_ITEM,      //< °°Àº Á¾·ù¸¸ °áÇÕÇÒ ¼ö ÀÖ½À´Ï´Ù.

		// _NA_000096_20100527_CHANGE_CHARACTER_APPEARANCE_SYSTEM
		RC_ITEM_FAIL_TO_CHANGE_CHARACTER_APPEARANCE, // Ä³¸¯ÅÍ ¿Ü¸ð º¯°æ ½ÇÆÐ

		// _NA_000251_20100727_SOCKET_SYSTEM
		RC_ITEM_NOT_UNIDENTIFIED_SOCKET,             // ¹ÌÈ®ÀÎ ¼ÒÄÏÀÌ ¾Æ´Ï´Ù.

		// _NA_002253_20100811_CUBE_SYSTEM
		RC_ITEM_SUCCESS_TO_COMPOSE_CUBE, // Å¥ºê ÇÕ¼º ¼º°ø
		RC_ITEM_FAILED_TO_COMPOSE_CUBE, // Å¥ºê ÇÕ¼º ½ÇÆÐ
		RC_ITEM_SUCCESS_TO_DECOMPOSE_CUBE, // Å¥ºê ºÐÇØ ¼º°ø
		RC_ITEM_FAILED_TO_DECOMPOSE_CUBE,  // Å¥ºê ºÐÇØ ½ÇÆÐ

		// _NA_000587_20100928_DOMINATION_BUFF_ITEM
		RC_ITEM_UNAVAILABLE_TARGET, // ÁöÁ¤µÈ ´ë»ó¿¡ ¾ÆÀÌÅÛÀ» »ç¿ëÇÒ ¼ö ¾ø½À´Ï´Ù.
		RC_ITEM_NOT_FRIEND, // ¾Æ±ºÀÌ ¾Æ´Õ´Ï´Ù.

		// _NA_20101011_HEIM_LOTTO_CASH_TICKET
		// Ä³½Ã ÀÀ¸ð±Ç »ç¿ëÀ¸·Î ÇÏÀÓÇà¿î ÀÀ¸ð ¿ëÁö È°¼ºÈ­ ½ÇÆÐ »çÀ¯
		RC_ITEM_HEIM_LOTTO_TICKET_MAX_REACHED,          // ÇÏÀÓÇà¿î º¹±Ç¿ëÁö º¸À¯ °³¼ö Á¦ÇÑ ÃÊ°ú
		RC_ITEM_HEIM_LOTTO_UNAVAILABLE,                 // ÃßÃ· µîÀÇ ÀÌÀ¯·Î ÀÏ½ÃÀûÀ¸·Î ±â´ÉÀ» »ç¿ëÇÒ ¼ö ¾øÀ½

		// _NA_000251_20100727_SOCKET_SYSTEM
		RC_ITEM_SUCCESS_TO_COMPOSE_ZARD, // Àðµå ÇÕ¼º ¼º°ø
		RC_ITEM_FAILED_TO_COMPOSE_ZARD, // Àðµå ÇÕ¼º ½ÇÆÐ

		RC_ITEM_SUCCESS_TO_GET_COMPOSITION_OR_DECOMPOSITION_HISTORIES, // ÃÖ±Ù¿¡ ¼º°øÇÑ ÇÕ¼º ¶Ç´Â ºÐÇØ ¸ñ·Ï ¾ò±â ¼º°ø
		RC_ITEM_FAILED_TO_GET_COMPOSITION_OR_DECOMPOSITION_HISTORIES, // ÃÖ±Ù¿¡ ¼º°øÇÑ ÇÕ¼º ¶Ç´Â ºÐÇØ ¸ñ·Ï ¾ò±â ½ÇÆÐ

		RC_ITEM_SOCKET_FAILED_TO_EXTRACT_BY_RATIO, // È®·ü·Î ÀÎÇØ Àðµå ÃßÃâ¿¡ ½ÇÆÐÇßÁö¸¸ ÃßÃâ ½Ãµµ ÀÚÃ¼´Â ¼º°ø
		RC_ITEM_SOCKET_FAILED_TO_FILL_BY_GRADE, // Àðµå µî±Þº° °³¼ö Á¦ÇÑ¿¡ °É·Á¼­ Àðµå ¹Ú±â ½ÇÆÐ

		//_NA_20110303_ADD_TYPE_OF_NPCSHOP
		RC_ITEM_IS_SHORT_HAVE_ITEM,             // ¾ÆÀÌÅÛ Å¸ÀÔ »óÁ¡¿¡¼­ ±¸ÀÔÇÏ±â À§ÇÑ ¼ÒÁö ¾ÆÀÌÅÛÀÌ ºÎÁ·ÇÏ´Ù.
		RC_ITEM_IS_SHORT_HAVE_ACCUMULATEPOINT,  // Àû¸³ Æ÷ÀÎÆ® »óÁ¡¿¡¼­ ±¸ÀÔÇÏ±â À§ÇÑ ¼ÒÁö Æ÷ÀÎÆ®°¡ ºÎÁ·ÇÏ´Ù.

		RC_ITEM_CANNOT_EQUIPMENT_BETAKEY,       //ÇØ´ç ¹èÅ¸Å°¸¦ °¡ÁöÁö ¸øÇÑ À¯Àú´Â ÀåÂøÇÒ¼ö ¾ø´Â ¾ÆÀÌÅÛÀÌ´Ù.
		RC_ITEM_CANNOT_USE_BETAKEY,             //ÇØ´ç ¹èÅ¸Å°¸¦ °¡ÁöÁö ¸øÇÑ À¯Àú´Â »ç¿ëÇÒ¼ö ¾ø´Â ¾ÆÀÌÅÛÀÌ´Ù.

		RC_ITEM_BUY_ERROR_OF_REPUTE,                   // ÆòÆÇÀÌ ºÎÁ·ÇØ¼­ ¾ÆÀÌÅÛÀ» ±¸¸Å ÇÒ ¼ö ¾ø´Ù.
		RC_ITEM_BUY_ERROR_OF_FAME,                     // ¸í¼ºÀÌ ºÎÁ·ÇØ¼­ ¾ÆÀÌÅÛÀ» ±¸¸Å ÇÒ ¼ö ¾ø´Ù.

		//_NA004034_20120102_POINT_WALLET_SYSTEM
		RC_ITEM_FAILED_TO_EXCHANGE_CURRENCY_ITEM_BY_LIMIT,  // ÃÖ´ë¼ÒÁöÁ¦ÇÑÀ¸·Î È­Æó¾ÆÀÌÅÛÀÇ È­ÆóÆ÷ÀÎÆ® È¯Àü ½ÇÆÐ
		RC_ITEM_FAILED_TO_BUY_BY_POINT,                     // È­ÆóÆ÷ÀÎÆ® ºÎÁ·À¸·Î ¾ÆÀÌÅÛ±¸ÀÔ ½ÇÆÐ

		//_NA004034_20120102_GUILD_POINT_SYSTEM
		RC_ITEM_GUILDCOIN_NOT_GUILD_MEMBER,                    // ±æµå¸â¹ö°¡ ¾Æ´Ô
		RC_ITEM_GUILDCOIN_NOT_ENOUGH_COIN,                     // ±æµåÄÚÀÎ ºÎÁ·
		RC_ITEM_GUILDCOIN_DONATION_SUCCESS,                    // ±æµåÄÚÀÎ ±âºÎ ¼º°ø
		RC_ITEM_GUILDCOIN_DONATION_COUNT_OVER,                 // ±âºÎ È½¼ö ÃÊ°ú        
		RC_ITEM_GUILDCOIN_EXCEED_MAX_LEVEL,                    // ÃÖ°í ·¹º§ÀÌ¹Ç·Î ´õÀÌ»ó ±âºÎ°¡ ¾ÈµÊ
		RC_ITEM_BUY_ERROR_GUILD_LEVEL,                          // ±æµå ·¹º§ÀÌ ºÎÁ·ÇÒ¶§
		RC_ITEM_BUY_ERROR_GUILD_EXP,                            // ±æµå °øÇåµµ°¡ ºÎÁ·ÇÒ¶§

		RC_ITEM_GUILDFACILITY_NOT_GUILD_MEMBER,            // ±æµå ¸â¹ö°¡ ¾Æ´Ï´Ù
		RC_ITEM_GUILDFACILITY_NONE_USE_RIGHT,              // »ç¿ë ±ÇÇÑÀÌ ¾ø´Ù

		// _NA_008121_20150311_EQUIPMENT_AWAKENING_SYSTEM
		RC_EQUIPMENT_AWAKENING_SUCCESS,                         // °¢¼º ¼º°ø
		RC_EQUIPMENT_AWAKENING_FAIL,                            // °¢¼º ½ÇÆÐ
		RC_EQUIPMENT_AWAKENING_EQUIP_EXCEEDED_PERMIT_LEVEL,     // Àåºñ °¢¼º Çã¿ë ·¹º§À» ³Ñ¾ú´Ù.
		RC_EQUIPMENT_AWAKENING_EQUIP_MAX_LEVEL,                 // Àåºñ °¢¼º ·¹º§ÀÌ ÃÖ°í·¹º§ ÀÔ´Ï´Ù
		RC_EQUIPMENT_AWAKENING_DOES_NOT_MATCH_ADDITIVE,         // Ã·°¡Á¦ ¾ÆÀÌÅÛÀÌ ¸ÂÁö ¾Ê´Â´Ù
		RC_EQUIPMENT_AWAKENING_DOES_NOT_MATCH_ADDITIVE_AMOUNT,  // Ã·°¡Á¦ ¾ÆÀÌÅÛÀÇ ¼ö·®ÀÌ ¸ÂÁö ¾Ê´Â´Ù
		RC_EQUIPMENT_AWAKENING_DOES_NOT_MATCH_MATERIAL,         // Àç·á ¾ÆÀÌÅÛÀÌ ¸ÂÁö ¾Ê´Â´Ù
		RC_EQUIPMENT_AWAKENING_DOES_NOT_MATCH_MATERIAL_AMOUNT,  // Àç·á ¾ÆÀÌÅÛÀÇ ¼ö·®ÀÌ ¸ÂÁö ¾Ê´Â´Ù
		RC_EQUIPMENT_AWAKENING_INVALID_EQUIP_INFO,              // Àåºñ Á¤º¸¸¦ ¾Ë ¼ö ¾ø´Ù
		RC_EQUIPMENT_AWAKENING_INVALID_MATERIAL_INFO,           // Àç·á Á¤º¸¸¦ ¾Ë ¼ö ¾ø´Ù
		RC_EQUIPMENT_AWAKENING_INVALID_AWAKENING_INFO,          // °¢¼º Á¤º¸¸¦ ¾Ë ¼ö ¾ø´Ù

		RC_EQUIPMENT_EVOLUTION_SUCCESS,                         // ÁøÈ­ ¼º°ø
		RC_EQUIPMENT_EVOLUTION_FAIL,                            // ÁøÈ­ ½ÇÆÐ
		RC_EQUIPMENT_EVOLUTION_INVALID_EQUIP_INFO,              // Àåºñ Á¤º¸¸¦ ¾Ë ¼ö ¾ø´Ù
		RC_EQUIPMENT_EVOLUTION_ITEM_CAN_NOT_EVOLUTION,          // ÁøÈ­ ½ÃÅ³ ¼ö ¾ø´Â ¾ÆÀÌÅÛ ÀÔ´Ï´Ù
		RC_EQUIPMENT_EVOLUTION_DOES_NOT_MATCH_ADDITIVE,         // Ã·°¡Á¦ ¾ÆÀÌÅÛÀÌ ¸ÂÁö ¾Ê´Â´Ù
		RC_EQUIPMENT_EVOLUTION_DOES_NOT_MATCH_ADDITIVE_AMOUT,   // Ã·°¡Á¦ ¾ÆÀÌÅÛÀÇ ¼ö·®ÀÌ ¸ÂÁö ¾Ê´Â´Ù
		RC_EQUIPMENT_EVOLUTION_DOES_NOT_MATCH_AWAKENING_GRADE,  // °¢¼º µî±ÞÀÌ ¸ÂÁö ¾Ê´Â´Ù

		RC_ITEM_SPA_COSTUME_INVALID_ITEM,                       // ¿ÂÃµÆ¼ÄÏÀÌ ¾Æ´Ï´Ù

		RC_ITEM_FAILED_EXIST_SEPARATE_NAK_PACKET,               // º°µµÀÇ NAK ÆÐÅ¶ÀÌ Á¸ÀçÇÑ´Ù

		//------------------------------------------------------------------------------------------
		// (CHANGES) (f100517.2L) must be last settled
		RC_ITEM_PROCESS_PENDING,                        // ¼­¹ö°£ ¿¬µ¿ µîÀÇ ÀÌÀ¯·Î °á°ú¸¦ Áï½Ã ÆÇÁ¤ÇÒ ¼ö ¾ø¾î Ã³¸® º¸·ù
		RC_ITEM_UPPERBOUND                              // ¾ÆÀÌÅÛ °á°ú ÄÚµå »óÇÑ°ª
	}; // eITEM_RESULT
	public enum BattleResult
	{
		RC_BATTLE_SUCCESS,

		RC_BATTLE_PLAYER_NOTEXIST_TO_FIELD,                 //< ÇÃ·¹ÀÌ¾î°¡ ÇÊµå¿¡ Á¸ÀçÇÏÁö ¾Ê´Â´Ù.
		RC_BATTLE_INVALID_MAINTARGET,                       //< ¸ÞÀÎÅ¸°ÙÀ» Ã£À» ¼ö ¾ø´Ù.
		RC_BATTLE_PLAYER_STATE_WHERE_CANNOT_ATTACK_ENEMY,   //< °ø°ÝÀÚ°¡ ÀûÀ» °ø°ÝÇÒ ¼ö ¾ø´Â »óÅÂÀÌ´Ù.
		RC_BATTLE_VKR_RELOAD_COUNT_LACK,                    //< ¹ßÅ°¸® ÀåÀü°³¼ö ºÎÁ· 
		RC_BATTLE_TRAGET_STATE_WHERE_CANNOT_ATTACKED,       //< Å¸°ÙÀÌ °ø°Ý¹ÞÀ» ¼ö ¾ø´Â »óÅÂÀÌ´Ù.
		RC_BATTLE_OUT_OF_RANGE,                             //< ¸ÞÀÎÅ¸°ÙÀÌ °ø°Ý»ç°Å¸®¿¡¼­ ¹þ¾î³²
		RC_BATTLE_INVLIDPOS,                                //< Àß¸øµÈ À§Ä¡Á¤º¸°¡ ¿Ô½À´Ï´Ù.
		RC_BATTLE_THRUST_DIST_OVER,                         //< Å¬¶ó¿¡¼­ º¸³»´Â ¹Ð¸®´Â °Å¸®°¡ ³Ê¹« ±æ´Ù.(ÇØÅ· °¡´É¼º)
		RC_BATTLE_ALREADY_DOING_ACTION,                     //< ÀÌ¹Ì °ø°ÝÁßÀÎ »óÅÂÀÌ´Ù.
		RC_BATTLE_BASEINFO_NOTEXIST,                        //< BaseStyleInfo°¡ ¾ø´Ù.
		RC_BATTLE_STYLECODE_WHERE_DONOT_SELECT,             //< ¼±ÅÃÇÏÁö ¾ÊÀº ½ºÅ¸ÀÏÄÚµå
		RC_BATTLE_CHAR_CLASS_LIMIT,                         //< Å¬·¡½º Á¦ÇÑ(±× ½ºÅ¸ÀÏÀ» »ç¿ëÇÒ ¼ö ¾ø´Â Ä³¸¯ÅÍ Å¸ÀÔÀÌ´Ù)
		RC_BATTLE_WEAPON_LIMIT,                             //< ¹«±â Á¦ÇÑ
		RC_BATTLE_FIELD_IS_NULL,
		RC_BATTLE_ATTACKER_LEVEL_IS_LOW,                    //< °ø°ÝÀÚ ·¹º§ÀÌ ³·¾Æ¼­ PK¸¦ ÇÒ ¼ö ¾ø´Ù.
		RC_BATTLE_TARGET_LEVEL_IS_LOW,                      //< Å¸°Ù ·¹º§ÀÌ ³·¾Æ¼­ PK¸¦ ´çÇÒ ¼ö ¾ø´Ù.
		RC_BATTLE_ISNOT_PK_ZONE,                            //< PK°¡ °¡´ÉÇÑ Áö¿ªÀÌ ¾Æ´Ï´Ù.
		RC_BATTLE_ISNOT_PK_SERVER,                          //< PK°¡ °¡´ÉÇÑ ¼­¹ö°¡ ¾Æ´Ï´Ù.
		RC_BATTLE_SERVER_STATE_IMPOSSIBLE_PK,               //< PK°¡ ºÒ°¡´ÉÇÑ ¼­¹ö»óÅÂÀÌ´Ù.
		RC_BATTLE_PK_IMPOSSIBLE_TARGET_TYPE,                //< PK°¡ ºÒ°¡´ÉÇÑ Å¸°ÙÅ¸ÀÔÀÌ´Ù.
		RC_BATTLE_ALLIENCE_GUILD_CHARACTER,                 //< µ¿¸Í ±æµå Ä³¸¯ÅÍÀÌ¹Ç·Î PK ºÒ°¡´É

		RC_BATTLE_ISNOT_TROUBLED_PART,                      //< Å¸ÀÏÀÌ ºÐÀï Áö¿ªÀÌ ¾Æ´Ï´Ù
		RC_BATTLE_PLAYER_TILE_INVLIDPOS,                    //< ´ë»óÀÇ Å¸ÀÏÀÌ Á¸ÀçÇÏÁö ¾Ê´Â´Ù.
		RC_BATTLE_FAILED,                                   //< ±âÅ¸¿øÀÎÀÇ ½ÇÆÐ
		RC_BATTLE_SAME_GUILD_CHARACTER,                     //< °°Àº ±æµå¿øÀÌ´Ù.
		RC_BATTLE_SAME_PARTY_CHARACTER,                     //< °°Àº ÆÄÆ¼¿øÀÌ´Ù.

		//__NA_000921_20080227_TROUBLED_PARTS               //< Å¬¶óÀÌ¾ðÆ® »ç¿ë ¾ÈÇÒ½Ã »èÁ¦µÉ µ¥ÀÌÅÍ
		RC_BATTLE_ISNOT_CHAO_PART,                          //< Ä«¿À °¡´ÉÇÑ Áö¿ªÀÌ ¾Æ´Ï´Ù.	//»ç¿ë¹«
		RC_BATTLE_ISNOT_TROUBLED_ZONE,                      //< ºÐÀï °¡´ÉÇÑ Áö¿ªÀÌ ¾Æ´Ï´Ù.	//»ç¿ë¹«
		RC_BATTLE_IMPOSSIBLE_PACKET_DATA,                   //< ÆÐÅ¶ µ¥ÀÌÅÍ°¡ Çü½Ä¿¡ ¸ÂÁö ¾Ê´Â´Ù. //»ç¿ë¹«
	};
    public enum SkillResult
    {
        RC_SKILL_SUCCESS,
        RC_SKILL_FAILED,                            //< ±âÅ¸¿øÀÎÀÇ ½ÇÆÐ

        RC_SKILL_BASEINFO_NOTEXIST,                 //< BaseSkillInfo°¡ ¾ø´Ù.

        RC_SKILL_STATE_WHERE_CANNOT_ATTACK_ENEMY,   //< ÀûÀ» °ø°ÝÇÒ ¼ö ¾ø´Â »óÅÂÀÌ´Ù.
        RC_SKILL_COOLTIME_ERROR,                    //< ¾ÆÁ÷ ÄðÅ¸ÀÓÀÌ ³¡³ªÁö ¾Ê¾Ò´Ù.
        RC_SKILL_HPMP_RUN_SHORT,                    //< HP, MP ºÎÁ·
        RC_SKILL_CHAR_CLASS_LIMIT,                  //< Å¬·¡½º Á¦ÇÑ(±× ½ºÅ³À» »ç¿ëÇÒ ¼ö ¾ø´Â Ä³¸¯ÅÍ Å¸ÀÔÀÌ´Ù)
        RC_SKILL_WEAPON_LIMIT,                      //< ¹«±â Á¦ÇÑ
        RC_SKILL_SEALING_STATE,                     //< ºÀÀÎ »óÅÂ°¡ °É·ÁÀÖ´Ù.
        RC_SKILL_OUT_OF_RANGE,                      //< ½ºÅ³ »ç°Å¸®¿¡¼­ ¹þ¾î³­´Ù.

        RC_SKILL_REQUIRE_LEVEL_LIMIT,               //< ¿ä±¸·¹º§ Á¦ÇÑ
        RC_SKILL_REQUIRE_SKILLSTAT_LIMIT,           //< ¿ä±¸¼÷·Ãµµ Á¦ÇÑ
        RC_SKILL_DOES_NOT_HAVE,                     //< ½ºÅ³À» °¡Áö°í ÀÖÁö ¾Ê´Ù.
        RC_SKILL_REMAIN_SKILLPOINT_LACK,            //< ³²Àº ½ºÅ³Æ÷ÀÎÆ®°¡ ½ºÅ³·¹º§À» ¿Ã¸®±â¿¡´Â ºÎÁ·ÇÏ´Ù.
        RC_SKILL_MAX_LEVEL_LIMIT,                   //< ÀÌ¹Ì ¸¸·¾ÀÌ¶ó¼­ ´õÀÌ»ó ½ºÅ³Æ÷ÀÎÆ®¸¦ ¿Ã¸± ¼ö ¾ø´Ù.
        RC_SKILL_ALREADY_EXIST_SKILL,               //< ÀÌ¹Ì Á¸ÀçÇÏ´Â ½ºÅ³ÀÌ´Ù.

        RC_SKILL_INVALID_STATE,                     //< ÇÃ·¹ÀÌ¾îÀÇ »óÅÂ°¡ À¯È¿ÇÏÁö ¾Ê½À´Ï´Ù.
        RC_SKILL_NOTEXIST,                          //< ½ºÅ³ÀÌ Á¸ÀçÇÏÁö ¾Ê½À´Ï´Ù.
        RC_SKILL_INVLIDPOS,                         //< Àß¸øµÈ À§Ä¡Á¤º¸°¡ ¿Ô½À´Ï´Ù.

        RC_SKILL_FIGHTING_ENERGY_FULL,              //< Åõ±â°³¼ö°¡ ÃÖ´ëÄ¡¹Ç·Î ´õÀÌ»ó ¿Ã¸± ¼ö ¾ø´Ù.

        RC_SKILL_POSITION_INVALID,                  //< ÁÂÇ¥°¡ À¯È¿ÇÏÁö ¾Ê´Ù.

        RC_SKILL_SUMMONED_NOTEXIST,                 //< ¼ÒÈ¯Ã¼°¡ Á¸ÀçÇÏÁö ¾Ê´Â´Ù.
        RC_SKILL_TARGET_NOTEXIST,                   //< Å¸°ÙÀÌ Á¸ÀçÇÏÁö ¾Ê´Â´Ù.
    };
    public enum ConditionResult
    {
        RC_CONDITION_SUCCESS,
        RC_CONDITION_ALREADY_SAME_CONDITION,                //< ÀÌ¹Ì °°Àº »óÅÂÀÌ´Ù.
        RC_CONDITION_INVALID_CONDITION,                     //< Á¸ÀçÇÏÁö ¾Ê´Â »óÅÂÀÌ´Ù.
        RC_CONDITION_DOING_ACTION,                          //< ´Ù¸¥ µ¿ÀÛÀ» ÁøÇàÁßÀÌ´Ù.
        RC_CONDITION_DRAGON_TRANSFORMATION_LIMIT,           //< µå·¡°ï º¯½Å »óÅÂ¿¡¼­´Â »óÅÂÀüÈ¯ ºÒ°¡
        RC_CONDITION_FAILED,
    };

}
