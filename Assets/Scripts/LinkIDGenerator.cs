using UnityEngine;
using System.Collections;

//this is the class of linkid generation algorithm.
public static class LinkIDGenerator
{
    public static string getUUIDLinkId()
    {
        return System.Guid.NewGuid().ToString();
    }
}
