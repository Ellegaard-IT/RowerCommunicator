using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace RowerCommunicator
{
    public static class RowerMethods
    {
        /// <summary>
        ///     About:      Initializes the Command Set Toolkit functions.
        ///     
        ///     Inputs:     None
        ///     
        ///     Outputs:    None
        /// </summary>
        /// <returns> ERRCODE_T   ecode       Zero if successful / Error code otherwise</returns>
        [DllImport("PM3USBCP.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint tkcmdsetUSB_init();

        /// <summary>
        ///     Returns the current version number of this software.
        ///     
        ///     Inputs:     None
        ///     
        ///     Outputs:    None
        /// </summary>
        /// <returns>UINT16_T    ver_info    High byte is major version number / Low byte is minor version number</returns>
        [DllImport("PM3USBCP.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint tkcmdsetUSB_get_dll_version();

        /// <summary>
        ///    About:      Reads status information from the device
        ///    Inputs:     UINT16_T    port        Identifier for device
        ///    
        ///    Outputs:    UINT32_T *  stat_ptr    Location to store status information
        /// </summary>
        /// <param name="port"></param>
        /// <param name="cmd_ptr"></param>
        /// <param name="cmd_len"></param>
        /// <returns> ERRCODE_T   ecode       Zero if successful / Error code otherwise </returns>
        [DllImport("PM3USBCP.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern uint tkcmdsetUSB_status(UInt16 port, UInt32* stat_ptr);

        /// <summary>
        ///     About:      Display a message on the PM
        ///     Inputs:     UINT16_T    port        Identifier for device
        ///                 UINT8_T *   cmd_ptr     Location of data to send to device
        ///                 UINT16_T    cmd_len     Length of data to send
        ///     
        ///     Outputs:    Nothing
        /// </summary>
        /// <param name="port"></param>
        /// <param name="stat_ptr"></param>
        /// <returns> ERRCODE_T   ecode       Zero if successful / Error code otherwise </returns>
        [DllImport("PM3USBCP.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern uint tkcmdsetUSB_echo(UInt16 port, uint* cmd_ptr, UInt16 cmd_len);

        /// <summary>
        ///     About:      Gets port numbers of all USB HID devices that match the product name
        ///     
        ///     Inputs:     INT8_T *    product_name Name of USB device to open
        ///     
        ///     Outputs:    UINT8_T *   num_found   Number of devices that match name
        ///                 UINT16_T    port_list[] Port numbers of devices that match
        /// </summary>
        /// <returns> ERRCODE_T   ecode       Zero if successful / Error code otherwise </returns>
        [DllImport("PM3USBCP.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern uint tkcmdsetUSB_find_devices(int* product_name,out uint* num_found,out UInt16[] port_list);

        /// <summary>
        ///     About:      Handle the command / response transaction with the USB device
        ///        
        ///     Inputs:     UINT16_T    port        Identifier for device
        ///                 UINT8_T *   tx_ptr      Pointer to data block to be transmitted
        ///                 UINT16_T    timeout     Time to wait for response in milliseconds
        ///                 
        ///     Outputs:    UINT8_T *   rx_ptr      Pointer to data block to save received data
        /// </summary>
        /// <returns>ERRCODE_T   ecode       Zero if successful / Error code otherwise</returns>
        [DllImport("PM3USBCP.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern uint tkcmdsetUSB_do_command(UInt16 port, uint* tx_ptr, UInt16 tx_len, uint* rx_ptr,UInt16* rx_len,UInt16 timeout);

        /// <summary>
        ///     About:   Send an asynchronous command to the USB device.
        ///     
        ///     Inputs:  UINT16_T    port				Identifier for device
        ///              UINT8_T *   tx_ptr			Pointer to data block to be transmitted
        ///              UINT16_T	   tx_len			Transmit buffer length
        ///              UINT16_T	   rx_len			Receive buffer length
        ///              UINT16_T	   cmd_tag			Identifier Tag to pass back to the caller on recv
        ///              
        ///     Outputs: None
        /// </summary>
        /// <returns>ERRCODE_T   ecode			   Zero if successful / Error code otherwise</returns>
        [DllImport("PM3USBCP.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern uint tkcmdsetUSB_send_command(UInt16 port, uint* tx_ptr,UInt16 tx_len, UInt16 rx_len, UInt16 cmd_tag);

        /// <summary>
        ///     About:      Send and receive a data block from the DDI interface.
        ///     
        ///     Inputs:     UINT16_T    port        Identifier for device
        ///                 UINT8_T *   cmd_ptr     Pointer to data block to be transmitted
        ///                 UINT16_T    cmd_len     Number of bytes in the command
        ///                 UINT16_T    timeout     Time to wait for response in milliseconds
        ///                 
        ///     Outputs:    UINT8_T *   rsp_ptr     Pointer to data block to save received data
        ///                 UINT16_T*   rsp_len     Number of bytes in the response
        /// </summary>
        /// <returns>ERRCODE_T   ecode       Zero if successful / Error code otherwise</returns>
        [DllImport("PM3USBCP.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern uint tkcmdsetUSB_do_DDIcommand(UInt16 port, uint* cmd_ptr, UInt16 cmd_len,uint* rsp_ptr, UInt16* rsp_len, UInt16 timeout);

        /// <summary>
        ///     About:      Reads the firmware version information from the PM3
        ///     
        ///     Inputs:     UINT16_T    port        Communication port to use
        ///     
        ///     Outputs:    UINT8_T *   ver_ptr     FW version string stored at this location
        /// </summary>
        /// <returns>ERRCODE_T   ecode       Zero if successful / Error code otherwise</returns>
        [DllImport("PM3USBCP.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern uint tkcmdsetUSB_fw_version(UInt16 port, int* ver_ptr, uint ver_len);

        /// <summary>
        ///     About:      Resets a single USB device by closing and opening the specified port
        ///     
        ///     Inputs:     UINT16_T    port        Communication port to use
        ///     
        ///     Outputs:    None
        /// </summary>
        /// <returns>Returns:    ERRCODE_T   ecode       Zero if successful / Error code otherwise</returns>
        [DllImport("PM3USBCP.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint tkcmdsetUSB_reset_port(UInt16 port);

        /// <summary>
        ///     About:      Shuts down a single USB device and releases associated resources
        ///     
        ///     Inputs:     UINT16_T    port        Communication port to use
        ///     
        ///     Outputs:    None
        /// </summary>
        /// <returns>ERRCODE_T   ecode       Zero if successful / Error code otherwise</returns>
        [DllImport("PM3USBCP.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint tkcmdsetUSB_shutdown(UInt16 port);
    }
}
