using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HRESULT = System.UInt32;

namespace PatcherYRpp
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDirectDrawSurface
    {
        HRESULT AddAttachedSurface(Pointer<IDirectDrawSurface> lpDDSAttachedSurface);
        HRESULT AddOverlayDirtyRect(Pointer<Rect> lpDirtyRect);
        HRESULT Blt(Pointer<Rect> lpDestRect, Pointer<IDirectDrawSurface> lpDDSrcSurface, Pointer<Rect> lpSrcRect, uint dwFlags, IntPtr lpDDBltFx);
        HRESULT BltBatch(IntPtr lpDDBltBatch, uint dwCount, uint dwFlags);
        HRESULT BltFast(uint dwX, uint dwY, Pointer<IDirectDrawSurface> lpDDSrcSurface, Pointer<Rect> lpSrcRect, uint dwTrans);
        HRESULT DeleteAttachedSurface(uint dwFlags, Pointer<IDirectDrawSurface> lpDDSAttachedSurface);
        HRESULT EnumAttachedSurfaces(IntPtr lpContext, IntPtr lpEnumSurfacesCallback);
        HRESULT EnumOverlayZOrders(uint dwFlags, IntPtr lpContext, IntPtr lpfnCallback);
        HRESULT Flip(Pointer<IDirectDrawSurface> lpDDSurfaceTargetOverride, uint dwFlags);
        HRESULT GetAttachedSurface(IntPtr lpDDSCaps, Pointer<IDirectDrawSurface> lplpDDAttachedSurface);
        HRESULT GetBltStatus(uint dwFlags);
        HRESULT GetCaps(IntPtr lpDDCaps);
        HRESULT GetClipper(IntPtr lplpDDClipper);
        HRESULT GetColorKey(uint dwFlags, IntPtr lpDDColorKey);
        HRESULT GetDC(IntPtr lphDC);
        HRESULT GetFlipStatus(uint dwFlags);
        HRESULT GetOverlayPosition(Pointer<int> lplX, Pointer<int> lplY);
        HRESULT GetPalette(IntPtr lplpDDPalette);
        HRESULT GetPixelFormat(IntPtr lpDDPixelFormat);
        HRESULT GetSurfaceDesc(IntPtr lpDDSurfaceDesc);
        HRESULT Initialize(IntPtr lpDD, IntPtr lpDDSurfaceDesc);
        HRESULT IsLost();
        HRESULT Lock(Pointer<Rect> lpDestRect, IntPtr lpDDSurfaceDesc, uint dwFlags, IntPtr hEvent);
        HRESULT ReleaseDC(IntPtr hDC);
        HRESULT Restore();
        HRESULT SetClipper(IntPtr lpDirectDrawClipper);
        HRESULT SetColorKey(uint dwFlags, IntPtr lpDDColorKey);
        HRESULT GetOverlayPosition(int lX, int lY);
        HRESULT SetPalette(IntPtr lpDDPalette);
        HRESULT Unlock(IntPtr lpSurfaceData);
        HRESULT UpdateOverlay(Pointer<Rect> lpSrcRect, Pointer<IDirectDrawSurface> lpDDDestSurface, Pointer<Rect> lpDestRect, uint dwFlags, IntPtr lpDDOverlayFx);
        HRESULT UpdateOverlayDisplay(uint dwFlags);
        HRESULT UpdateOverlayZOrder(uint dwFlags, Pointer<IDirectDrawSurface> lpDDSReference);
    }

}
