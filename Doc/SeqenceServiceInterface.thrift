namespace * RPC.ThriftInterface /*命名空间*/

service SeqenceServiceInterface /*service关键字相关于C#中的class关键字 后面接类名*/
{
    /*获取id序列接口*/
    i32 GetIDSeqence(1:string tableName), /*参数字段前加数字标记*/

    /*获取单号序列接口*/
    i32 GetCodeSeqence(
        1:i32 type,
        2:string id),
}