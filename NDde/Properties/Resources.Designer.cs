﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NDde.Properties {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("NDde.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The server failed to advise &quot;${service}|${topic}!${item}&quot;..
        /// </summary>
        internal static string AdviseFailedMessage {
            get {
                return ResourceManager.GetString("AdviseFailedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на An advise loop for &quot;${service}|${topic}!${item}&quot; already exists..
        /// </summary>
        internal static string AlreadyBeingAdvisedMessage {
            get {
                return ResourceManager.GetString("AlreadyBeingAdvisedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The client is already connected..
        /// </summary>
        internal static string AlreadyConnectedMessage {
            get {
                return ResourceManager.GetString("AlreadyConnectedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The context is already intialized..
        /// </summary>
        internal static string AlreadyInitializedMessage {
            get {
                return ResourceManager.GetString("AlreadyInitializedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The specified conversation is already paused..
        /// </summary>
        internal static string AlreadyPausedMessage {
            get {
                return ResourceManager.GetString("AlreadyPausedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The service is already registered..
        /// </summary>
        internal static string AlreadyRegisteredMessage {
            get {
                return ResourceManager.GetString("AlreadyRegisteredMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The IAsyncResult must have been returned by a call to ${method}..
        /// </summary>
        internal static string AsyncResultParameterInvalidMessage {
            get {
                return ResourceManager.GetString("AsyncResultParameterInvalidMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The client failed to pause the conversation..
        /// </summary>
        internal static string ClientPauseFailedMessage {
            get {
                return ResourceManager.GetString("ClientPauseFailedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The client failed to resume the conversation..
        /// </summary>
        internal static string ClientResumeFailedMessage {
            get {
                return ResourceManager.GetString("ClientResumeFailedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The client failed to connect to &quot;${service}|${topic}&quot;.  Make sure the server application is running and that it supports the specified service name and topic name pair..
        /// </summary>
        internal static string ConnectFailedMessage {
            get {
                return ResourceManager.GetString("ConnectFailedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The client failed to execute &quot;${command}&quot;..
        /// </summary>
        internal static string ExecuteFailedMessage {
            get {
                return ResourceManager.GetString("ExecuteFailedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The transaction filter has already been added..
        /// </summary>
        internal static string FilterAlreadyAddedMessage {
            get {
                return ResourceManager.GetString("FilterAlreadyAddedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The transaction filter has not been added..
        /// </summary>
        internal static string FilterNotAddedMessage {
            get {
                return ResourceManager.GetString("FilterNotAddedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The context failed to initialize..
        /// </summary>
        internal static string InitializeFailedMessage {
            get {
                return ResourceManager.GetString("InitializeFailedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The context timed out attempting to marshal the operation..
        /// </summary>
        internal static string MarshalTimeoutMessage {
            get {
                return ResourceManager.GetString("MarshalTimeoutMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The context is not hosted on a thread with a message loop..
        /// </summary>
        internal static string NoMessageLoopMessage {
            get {
                return ResourceManager.GetString("NoMessageLoopMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на An advise loop for &quot;${service}|${topic}!${item}&quot; does not exist..
        /// </summary>
        internal static string NotBeingAdvisedMessage {
            get {
                return ResourceManager.GetString("NotBeingAdvisedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The client is not connected..
        /// </summary>
        internal static string NotConnectedMessage {
            get {
                return ResourceManager.GetString("NotConnectedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The context is not initialized..
        /// </summary>
        internal static string NotInitializedMessage {
            get {
                return ResourceManager.GetString("NotInitializedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The specified conversation is not paused..
        /// </summary>
        internal static string NotPausedMessage {
            get {
                return ResourceManager.GetString("NotPausedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The service is not registered..
        /// </summary>
        internal static string NotRegisteredMessage {
            get {
                return ResourceManager.GetString("NotRegisteredMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The client failed to poke &quot;${service}|${topic}!${item}&quot;..
        /// </summary>
        internal static string PokeFailedMessage {
            get {
                return ResourceManager.GetString("PokeFailedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The server failed to register &quot;${service}&quot;..
        /// </summary>
        internal static string RegisterFailedMessage {
            get {
                return ResourceManager.GetString("RegisterFailedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The client failed to request &quot;${service}|${topic}!${item}&quot;..
        /// </summary>
        internal static string RequestFailedMessage {
            get {
                return ResourceManager.GetString("RequestFailedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The server failed to pause all conversations..
        /// </summary>
        internal static string ServerPauseAllFailedMessage {
            get {
                return ResourceManager.GetString("ServerPauseAllFailedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The server failed to pause the specified conversation..
        /// </summary>
        internal static string ServerPauseFailedMessage {
            get {
                return ResourceManager.GetString("ServerPauseFailedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The server failed to resume all conversations..
        /// </summary>
        internal static string ServerResumeAllFailedMessage {
            get {
                return ResourceManager.GetString("ServerResumeAllFailedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The server failed to resume the specified conversation..
        /// </summary>
        internal static string ServerResumeFailedMessage {
            get {
                return ResourceManager.GetString("ServerResumeFailedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The client failed to initiate an advise loop for &quot;${service}|${topic}!${item}&quot;..
        /// </summary>
        internal static string StartAdviseFailedMessage {
            get {
                return ResourceManager.GetString("StartAdviseFailedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The client failed to terminate the advise loop for &quot;${service}|${topic}!${item}&quot;..
        /// </summary>
        internal static string StopAdviseFailedMessage {
            get {
                return ResourceManager.GetString("StopAdviseFailedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The parameter must be &lt;= 255 characters..
        /// </summary>
        internal static string StringParameterInvalidMessage {
            get {
                return ResourceManager.GetString("StringParameterInvalidMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The parameter must be &gt; 0..
        /// </summary>
        internal static string TimeoutParameterInvalidMessage {
            get {
                return ResourceManager.GetString("TimeoutParameterInvalidMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на An unknown error occurred..
        /// </summary>
        internal static string UnknownErrorMessage {
            get {
                return ResourceManager.GetString("UnknownErrorMessage", resourceCulture);
            }
        }
    }
}