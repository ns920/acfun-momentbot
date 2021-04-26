
public class MomentEntity
{
    public int result { get; set; }
    public Feedlist[] feedList { get; set; }
    public string pcursor { get; set; }
    public string hostname { get; set; }
    public string requestId { get; set; }
}

public class Feedlist
{
    public string groupId { get; set; }
    public Moment moment { get; set; }
    public int bananaCount { get; set; }
    public string shareUrl { get; set; }
    public string coverUrl { get; set; }
    public int commentCount { get; set; }
    public string discoveryResourceFeedShowContent { get; set; }
    public int discoveryResourceFeedShowImageCount { get; set; }
    public int shareCount { get; set; }
    public int stowCount { get; set; }
    public User user { get; set; }
    public int viewCount { get; set; }
    public bool isFavorite { get; set; }
    public int createTimeGroup { get; set; }
    public int tagResourceType { get; set; }
    public int resourceType { get; set; }
    public int resourceId { get; set; }
    public int likeCount { get; set; }
    public int authorId { get; set; }
    public long createTime { get; set; }
    public Userinfo userInfo { get; set; }
    public string time { get; set; }
    public bool isThrowBanana { get; set; }
    public bool isLike { get; set; }
    public Hotcomment[] hotComments { get; set; }
    public string fansOnlyDesc { get; set; }
    public int videoSizeType { get; set; }
    public string videoId { get; set; }
    public string caption { get; set; }
    public object coverImgInfo { get; set; }
    public string playDuration { get; set; }
    public bool disableThrowBanana { get; set; }
    public Channel channel { get; set; }
    public string picShareUrl { get; set; }
    public Tag[] tag { get; set; }
}

public class Moment
{
    public int shareCount { get; set; }
    public Img[] imgs { get; set; }
    public int originResourceType { get; set; }
    public int bananaCount { get; set; }
    public int commentCount { get; set; }
    public string momentId { get; set; }
    public string replaceUbbText { get; set; }
    public string text { get; set; }
    public int momentType { get; set; }
    public bool isThrowBanana { get; set; }
}

public class Img
{
    public int width { get; set; }
    public int height { get; set; }
    public int size { get; set; }
    public string expandedUrl { get; set; }
    public string originUrl { get; set; }
    public string url { get; set; }
    public int type { get; set; }
}

public class User
{
    public string userHead { get; set; }
    public bool isFollowing { get; set; }
    public int[] verifiedTypes { get; set; }
    public bool isUpCollege { get; set; }
    public int nameColor { get; set; }
    public int verifiedType { get; set; }
    public string userName { get; set; }
    public int userId { get; set; }
}

public class Userinfo
{
    public int action { get; set; }
    public string href { get; set; }
    public string headUrl { get; set; }
    public int nameColor { get; set; }
    public int avatarFrame { get; set; }
    public int verifiedType { get; set; }
    public int[] verifiedTypes { get; set; }
    public string verifiedText { get; set; }
    public string contributeCount { get; set; }
    public int sexTrend { get; set; }
    public int followingStatus { get; set; }
    public bool isFollowing { get; set; }
    public string avatarFrameMobileImg { get; set; }
    public string avatarFramePcImg { get; set; }
    public string followingCount { get; set; }
    public int gender { get; set; }
    public Headcdnurl[] headCdnUrls { get; set; }
    public bool isJoinUpCollege { get; set; }
    public int followingCountValue { get; set; }
    public int fanCountValue { get; set; }
    public int contributeCountValue { get; set; }
    public string fanCount { get; set; }
    public string name { get; set; }
    public string signature { get; set; }
    public string id { get; set; }
}

public class Headcdnurl
{
    public string url { get; set; }
    public bool freeTrafficCdn { get; set; }
}

public class Channel
{
    public int parentId { get; set; }
    public string parentName { get; set; }
    public string name { get; set; }
    public int id { get; set; }
}

public class Hotcomment
{
    public string headUrl { get; set; }
    public int nameColor { get; set; }
    public int verifiedType { get; set; }
    public int[] verifiedTypes { get; set; }
    public string verifiedText { get; set; }
    public int videoId { get; set; }
    public int sourceId { get; set; }
    public int likeCount { get; set; }
    public int commentId { get; set; }
    public int userId { get; set; }
    public string userName { get; set; }
    public int sourceType { get; set; }
    public string content { get; set; }
    public bool isLiked { get; set; }
    public bool isArticle { get; set; }
    public bool isSignedUpCollege { get; set; }
}

public class Tag
{
    public int tagResourceCount { get; set; }
    public int tagId { get; set; }
    public string tagCountStr { get; set; }
    public string tagName { get; set; }
}
