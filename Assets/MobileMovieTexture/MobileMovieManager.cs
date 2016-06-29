/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

namespace MMT
{
    public class MobileMovieManager : MonoBehaviour
    {
        public static MobileMovieManager Instance;

#if (UNITY_ANDROID || UNITY_IPHONE) && !UNITY_EDITOR && (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3)
#if UNITY_IPHONE && !UNITY_EDITOR
        private const string PLATFORM_DLL = "__Internal";


		[DllImport(PLATFORM_DLL)]
		private static extern void MMTUnitySetGraphicsDevice(System.IntPtr device, int deviceType, int eventType);
#else
        private const string PLATFORM_DLL = "theorawrapper";

		[DllImport(PLATFORM_DLL)]
		private static extern void UnitySetGraphicsDevice(System.IntPtr device, int deviceType, int eventType);
#endif

        [DllImport(PLATFORM_DLL)]
		private static extern void UploadReadyPlaybackStates();

        

        enum GfxDeviceRenderer
        {
            kGfxRendererOpenGL = 0,          // OpenGL
            kGfxRendererD3D9,                // Direct3D 9
            kGfxRendererD3D11,               // Direct3D 11
            kGfxRendererGCM,                 // Sony PlayStation 3 GCM
            kGfxRendererNull,                // "null" device (used in batch mode)
            kGfxRendererHollywood,           // Nintendo Wii
            kGfxRendererXenon,               // Xbox 360
            kGfxRendererOpenGLES,            // OpenGL ES 1.1
            kGfxRendererOpenGLES20Mobile,    // OpenGL ES 2.0 mobile variant
            kGfxRendererMolehill,            // Flash 11 Stage3D
            kGfxRendererOpenGLES20Desktop,   // OpenGL ES 2.0 desktop variant (i.e. NaCl)
            kGfxRendererCount
        };

        enum GfxDeviceEventType
        {
            kGfxDeviceEventInitialize = 0,
            kGfxDeviceEventShutdown,
            kGfxDeviceEventBeforeReset,
            kGfxDeviceEventAfterReset,
        };
#endif

        void Awake()
        {
            Instance = this;

#if (UNITY_ANDROID || UNITY_IPHONE) && !UNITY_EDITOR && (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3)
            SetGraphicsDevice(System.IntPtr.Zero, (int)GfxDeviceRenderer.kGfxRendererOpenGLES20Mobile, (int)GfxDeviceEventType.kGfxDeviceEventInitialize);
            GL.InvalidateState();
#endif
        }

        void OnDestroy()
        {
            Instance = null;
        }

        void OnEnable()
        {
            StartCoroutine("DecodeCoroutine");
        }

        void OnDisable()
        {
            StopCoroutine("DecodeCoroutine");
        }

        private IEnumerator DecodeCoroutine()
        {
            // Wait until all frame rendering is done
            while (true)
            {
                //Start a frame decoding
                yield return new WaitForEndOfFrame();

#if (UNITY_ANDROID || UNITY_IPHONE) && !UNITY_EDITOR && (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3)
				UploadReadyPlaybackStates();
                GL.InvalidateState();
#else
                GL.IssuePluginEvent(7);
#endif

            }
        }
    }
}
