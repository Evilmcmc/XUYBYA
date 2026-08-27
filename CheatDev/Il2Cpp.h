#pragma once
#include <windows.h>
#include <string>
#include <cstring>
#include <vector>
#include <algorithm>
#include <cmath>

// --- IL2CPP Core Types ---
typedef void*   Il2CppDomain;
typedef void*   Il2CppThread;
typedef void*   Il2CppImage;
typedef void*   Il2CppClass;
typedef void*   Il2CppObject;
typedef void*   Il2CppString;
typedef void*   Il2CppArray;
typedef void*   FieldInfo;
typedef void*   MethodInfo;

struct Vector3 {
    float x, y, z;
    Vector3() : x(0), y(0), z(0) {}
    Vector3(float _x, float _y, float _z) : x(_x), y(_y), z(_z) {}

    Vector3 operator+(const Vector3& o) const { return Vector3(x + o.x, y + o.y, z + o.z); }
    Vector3 operator-(const Vector3& o) const { return Vector3(x - o.x, y - o.y, z - o.z); }
    Vector3 operator*(float s) const { return Vector3(x * s, y * s, z * s); }
    float Length() const { return sqrtf(x * x + y * y + z * z); }
    float LengthSq() const { return x * x + y * y + z * z; }
};

// --- Memory & Pointer Safety Helpers ---
inline bool IsValidMemPtr(const void* ptr, size_t size = 8) {
    if (!ptr) return false;
    uintptr_t u = (uintptr_t)ptr;
    if (u < 0x10000 || u >= 0x7FFFFFFFFFFF) return false;

    __try {
        volatile char c1 = *(const volatile char*)ptr;
        if (size > 1) {
            volatile char c2 = *((const volatile char*)ptr + size - 1);
            (void)c2;
        }
        (void)c1;
        return true;
    }
    __except (EXCEPTION_EXECUTE_HANDLER) {
        return false;
    }
}

inline bool IsValidIl2CppObj(void* obj) {
    if (!IsValidMemPtr(obj, 0x18)) return false;
    __try {
        void* klass = *(void**)obj;
        if (!IsValidMemPtr(klass, 0x20)) return false;
        return true;
    }
    __except (EXCEPTION_EXECUTE_HANDLER) {
        return false;
    }
}

inline bool IsValidUnityObj(void* obj) {
    if (!IsValidMemPtr(obj, 0x18)) return false;
    __try {
        void* klass = *(void**)obj;
        if (!IsValidMemPtr(klass, 0x20)) return false;
        void* cached = *(void**)((char*)obj + 0x10);
        if (!cached || !IsValidMemPtr(cached, 8)) return false;
        return true;
    }
    __except (EXCEPTION_EXECUTE_HANDLER) {
        return false;
    }
}

// --- IL2CPP Function Typedefs ---
typedef Il2CppDomain*  (*il2cpp_domain_get_t)();
typedef Il2CppThread*  (*il2cpp_thread_attach_t)(Il2CppDomain* domain);
typedef void*          (*il2cpp_domain_get_assemblies_t)(const Il2CppDomain* domain, size_t* size);
typedef Il2CppImage*   (*il2cpp_assembly_get_image_t)(const void* assembly);
typedef const char*    (*il2cpp_image_get_name_t)(Il2CppImage* image);
typedef Il2CppClass*   (*il2cpp_class_from_name_t)(const Il2CppImage* image, const char* namespaze, const char* name);
typedef MethodInfo*    (*il2cpp_class_get_method_from_name_t)(Il2CppClass* klass, const char* name, int argsCount);
typedef Il2CppObject*  (*il2cpp_runtime_invoke_t)(const MethodInfo* method, void* obj, void** params, void** exc);
typedef void*          (*il2cpp_object_get_class_t)(Il2CppObject* obj);
typedef void*          (*il2cpp_class_get_type_t)(Il2CppClass* klass);
typedef void*          (*il2cpp_type_get_object_t)(void* type);
typedef Il2CppString*  (*il2cpp_string_new_t)(const char* str);
typedef void*          (*il2cpp_resolve_icall_t)(const char* name);
typedef FieldInfo*     (*il2cpp_class_get_fields_t)(Il2CppClass* klass, void** iter);
typedef size_t         (*il2cpp_field_get_offset_t)(FieldInfo* field);
typedef const char*    (*il2cpp_field_get_name_t)(FieldInfo* field);
typedef void           (*il2cpp_field_static_get_value_t)(FieldInfo* field, void* value);

// --- Resolver Class ---
class Il2CppResolver {
public:
    HMODULE hGameAssembly = NULL;

    il2cpp_domain_get_t                 il2cpp_domain_get              = nullptr;
    il2cpp_thread_attach_t              il2cpp_thread_attach           = nullptr;
    il2cpp_domain_get_assemblies_t      il2cpp_domain_get_assemblies   = nullptr;
    il2cpp_assembly_get_image_t         il2cpp_assembly_get_image      = nullptr;
    il2cpp_image_get_name_t             il2cpp_image_get_name          = nullptr;
    il2cpp_class_from_name_t            il2cpp_class_from_name         = nullptr;
    il2cpp_class_get_method_from_name_t il2cpp_class_get_method_from_name = nullptr;
    il2cpp_runtime_invoke_t             il2cpp_runtime_invoke          = nullptr;
    il2cpp_object_get_class_t           il2cpp_object_get_class        = nullptr;
    il2cpp_class_get_type_t             il2cpp_class_get_type          = nullptr;
    il2cpp_type_get_object_t            il2cpp_type_get_object         = nullptr;
    il2cpp_string_new_t                 il2cpp_string_new              = nullptr;
    il2cpp_resolve_icall_t              il2cpp_resolve_icall           = nullptr;
    il2cpp_class_get_fields_t           il2cpp_class_get_fields        = nullptr;
    il2cpp_field_get_offset_t           il2cpp_field_get_offset        = nullptr;
    il2cpp_field_get_name_t             il2cpp_field_get_name          = nullptr;
    il2cpp_field_static_get_value_t     il2cpp_field_static_get_value  = nullptr;

    // Cached Unity / FishNet / Game class & method pointers
    Il2CppClass* classObject           = nullptr;
    Il2CppClass* classGameObject       = nullptr;
    Il2CppClass* classCamera           = nullptr;
    Il2CppClass* classTransform        = nullptr;
    Il2CppClass* classComponent        = nullptr;
    Il2CppClass* classRigidbody        = nullptr;
    Il2CppClass* classNetworkBehaviour = nullptr;
    Il2CppClass* classCursor           = nullptr;
    Il2CppClass* classBootstrapManager = nullptr;

    MethodInfo* methodFindObjectsOfType       = nullptr;
    MethodInfo* methodCameraGetMain           = nullptr;
    MethodInfo* methodCameraGetCurrent        = nullptr;
    MethodInfo* methodCameraGetAll            = nullptr;
    MethodInfo* methodWorldToScreen           = nullptr;
    MethodInfo* methodTransformGetPos         = nullptr;
    MethodInfo* methodTransformSetPos         = nullptr;
    MethodInfo* methodTransformLookAt         = nullptr;
    MethodInfo* methodTransformGetForward     = nullptr;
    MethodInfo* methodComponentGetTrans       = nullptr;
    MethodInfo* methodComponentGetComp        = nullptr;
    MethodInfo* methodComponentGetGameObject  = nullptr;
    MethodInfo* methodGameObjectGetActiveInH  = nullptr;
    MethodInfo* methodGameObjectSetActive     = nullptr;
    MethodInfo* methodGetIsOwner              = nullptr;
    MethodInfo* methodGetIsSpawned            = nullptr;
    MethodInfo* methodRbSetLinearVelocity     = nullptr;
    MethodInfo* methodRbSetAngularVelocity    = nullptr;
    MethodInfo* methodRbMovePosition          = nullptr;
    MethodInfo* methodSetCursorLockState      = nullptr;
    MethodInfo* methodSetCursorVisible        = nullptr;

    MethodInfo* methodBootstrapGetInstance    = nullptr;
    MethodInfo* methodBootstrapHostLobby      = nullptr;
    MethodInfo* methodBootstrapJoinLobby      = nullptr;
    MethodInfo* methodBootstrapLeaveLobby     = nullptr;
    MethodInfo* methodBootstrapGetLobbiesList = nullptr;

    bool Init() {
        hGameAssembly = GetModuleHandleA("GameAssembly.dll");
        if (!hGameAssembly) return false;

        #define LOAD(name) name = (name##_t)GetProcAddress(hGameAssembly, #name)
        LOAD(il2cpp_domain_get);
        LOAD(il2cpp_thread_attach);
        LOAD(il2cpp_domain_get_assemblies);
        LOAD(il2cpp_assembly_get_image);
        LOAD(il2cpp_image_get_name);
        LOAD(il2cpp_class_from_name);
        LOAD(il2cpp_class_get_method_from_name);
        LOAD(il2cpp_runtime_invoke);
        LOAD(il2cpp_object_get_class);
        LOAD(il2cpp_class_get_type);
        LOAD(il2cpp_type_get_object);
        LOAD(il2cpp_string_new);
        LOAD(il2cpp_resolve_icall);
        LOAD(il2cpp_class_get_fields);
        LOAD(il2cpp_field_get_offset);
        LOAD(il2cpp_field_get_name);
        LOAD(il2cpp_field_static_get_value);
        #undef LOAD

        AttachThread();
        InitUnityClasses();
        return true;
    }

    void EnsureThreadAttached() {
        thread_local bool t_IsAttached = false;
        if (!t_IsAttached && il2cpp_domain_get && il2cpp_thread_attach) {
            Il2CppDomain* domain = il2cpp_domain_get();
            if (domain) {
                il2cpp_thread_attach(domain);
                t_IsAttached = true;
            }
        }
    }

    void AttachThread() {
        EnsureThreadAttached();
    }

    Il2CppImage* GetImage(const char* assemblyName) {
        if (!il2cpp_domain_get_assemblies || !il2cpp_domain_get || !il2cpp_image_get_name)
            return nullptr;

        size_t size = 0;
        void** assemblies = (void**)il2cpp_domain_get_assemblies(il2cpp_domain_get(), &size);
        if (!assemblies) return nullptr;

        for (size_t i = 0; i < size; ++i) {
            Il2CppImage* image = il2cpp_assembly_get_image(assemblies[i]);
            if (!image) continue;
            const char* name = il2cpp_image_get_name(image);
            if (name && strstr(name, assemblyName))
                return image;
        }
        return nullptr;
    }

    Il2CppClass* FindClass(const char* assemblyName, const char* namespaze, const char* className) {
        Il2CppImage* img = GetImage(assemblyName);
        if (!img || !il2cpp_class_from_name) return nullptr;
        return il2cpp_class_from_name(img, namespaze, className);
    }

    MethodInfo* FindMethod(Il2CppClass* klass, const char* methodName, int argsCount) {
        if (!klass || !il2cpp_class_get_method_from_name) return nullptr;
        return il2cpp_class_get_method_from_name(klass, methodName, argsCount);
    }

    void InitUnityClasses() {
        Il2CppImage* core = GetImage("UnityEngine.CoreModule");
        if (core) {
            classObject     = il2cpp_class_from_name(core, "UnityEngine", "Object");
            classGameObject = il2cpp_class_from_name(core, "UnityEngine", "GameObject");
            classCamera     = il2cpp_class_from_name(core, "UnityEngine", "Camera");
            classTransform  = il2cpp_class_from_name(core, "UnityEngine", "Transform");
            classComponent  = il2cpp_class_from_name(core, "UnityEngine", "Component");

            if (classObject) {
                methodFindObjectsOfType = FindMethod(classObject, "FindObjectsOfType", 1);
            }
            if (classGameObject) {
                methodGameObjectGetActiveInH = FindMethod(classGameObject, "get_activeInHierarchy", 0);
                methodGameObjectSetActive    = FindMethod(classGameObject, "SetActive", 1);
            }
            if (classCamera) {
                methodCameraGetMain    = FindMethod(classCamera, "get_main", 0);
                methodCameraGetCurrent = FindMethod(classCamera, "get_current", 0);
                methodCameraGetAll     = FindMethod(classCamera, "get_allCameras", 0);
                methodWorldToScreen    = FindMethod(classCamera, "WorldToScreenPoint", 1);
            }
            if (classTransform) {
                methodTransformGetPos        = FindMethod(classTransform, "get_position", 0);
                methodTransformSetPos        = FindMethod(classTransform, "set_position", 1);
                methodTransformLookAt        = FindMethod(classTransform, "LookAt", 1);
                methodTransformGetForward    = FindMethod(classTransform, "get_forward", 0);
            }
            if (classComponent) {
                methodComponentGetTrans      = FindMethod(classComponent, "get_transform", 0);
                methodComponentGetComp       = FindMethod(classComponent, "GetComponent", 1);
                methodComponentGetGameObject = FindMethod(classComponent, "get_gameObject", 0);
            }
            classCursor = il2cpp_class_from_name(core, "UnityEngine", "Cursor");
            if (classCursor) {
                methodSetCursorLockState = FindMethod(classCursor, "set_lockState", 1);
                methodSetCursorVisible   = FindMethod(classCursor, "set_visible", 1);
            }
        }

        Il2CppImage* phys = GetImage("UnityEngine.PhysicsModule");
        if (phys) {
            classRigidbody = il2cpp_class_from_name(phys, "UnityEngine", "Rigidbody");
            if (classRigidbody) {
                methodRbSetLinearVelocity  = FindMethod(classRigidbody, "set_linearVelocity", 1);
                methodRbSetAngularVelocity = FindMethod(classRigidbody, "set_angularVelocity", 1);
                methodRbMovePosition       = FindMethod(classRigidbody, "MovePosition", 1);
            }
        }

        Il2CppImage* fishnet = GetImage("FishNet.Runtime");
        if (fishnet) {
            classNetworkBehaviour = il2cpp_class_from_name(fishnet, "FishNet.Object", "NetworkBehaviour");
            if (classNetworkBehaviour) {
                methodGetIsOwner   = FindMethod(classNetworkBehaviour, "get_IsOwner", 0);
                methodGetIsSpawned = FindMethod(classNetworkBehaviour, "get_IsSpawned", 0);
            }
        }

        Il2CppImage* asmCS = GetImage("Assembly-CSharp");
        if (asmCS) {
            classBootstrapManager = il2cpp_class_from_name(asmCS, "", "BootstrapManager");
            if (classBootstrapManager) {
                methodBootstrapGetInstance    = FindMethod(classBootstrapManager, "get_Instance", 0);
                methodBootstrapHostLobby      = FindMethod(classBootstrapManager, "HostLobby", 1);
                methodBootstrapLeaveLobby     = FindMethod(classBootstrapManager, "LeaveLobby", 0);
                methodBootstrapGetLobbiesList = FindMethod(classBootstrapManager, "GetLobbiesList", 1);
            }
        }
    }

    Il2CppArray* FindObjectsOfType(Il2CppClass* targetClass) {
        EnsureThreadAttached();
        if (!targetClass || !methodFindObjectsOfType || !il2cpp_class_get_type || !il2cpp_type_get_object || !il2cpp_runtime_invoke)
            return nullptr;

        void* typeObj = il2cpp_type_get_object(il2cpp_class_get_type(targetClass));
        if (!typeObj) return nullptr;

        void* args[1] = { typeObj };
        void* exc = nullptr;
        Il2CppObject* res = il2cpp_runtime_invoke(methodFindObjectsOfType, nullptr, args, &exc);
        if (exc || !res || !IsValidMemPtr(res, 0x20)) return nullptr;
        return (Il2CppArray*)res;
    }

    void* GetMainCamera() {
        EnsureThreadAttached();
        // 1. Try Camera.main
        if (methodCameraGetMain && il2cpp_runtime_invoke) {
            void* exc = nullptr;
            Il2CppObject* res = il2cpp_runtime_invoke(methodCameraGetMain, nullptr, nullptr, &exc);
            if (!exc && res && IsValidUnityObj(res)) return (void*)res;
        }

        // 2. Try Camera.current
        if (methodCameraGetCurrent && il2cpp_runtime_invoke) {
            void* exc = nullptr;
            Il2CppObject* res = il2cpp_runtime_invoke(methodCameraGetCurrent, nullptr, nullptr, &exc);
            if (!exc && res && IsValidUnityObj(res)) return (void*)res;
        }

        // 3. Try Camera.allCameras
        if (methodCameraGetAll && il2cpp_runtime_invoke) {
            void* exc = nullptr;
            Il2CppArray* arr = (Il2CppArray*)il2cpp_runtime_invoke(methodCameraGetAll, nullptr, nullptr, &exc);
            if (!exc && arr && IsValidMemPtr(arr, 0x28)) {
                uintptr_t cnt = *(uintptr_t*)((char*)arr + 0x18);
                if (cnt > 0 && cnt <= 32) {
                    void** items = (void**)((char*)arr + 0x20);
                    for (uintptr_t i = 0; i < cnt; i++) {
                        if (items[i] && IsValidUnityObj(items[i])) return items[i];
                    }
                }
            }
        }
        return nullptr;
    }

    void* GetComponent(void* componentOrObj, Il2CppClass* targetTypeClass) {
        EnsureThreadAttached();
        if (!IsValidUnityObj(componentOrObj) || !targetTypeClass || !methodComponentGetComp || !il2cpp_runtime_invoke)
            return nullptr;

        void* typeObj = il2cpp_type_get_object(il2cpp_class_get_type(targetTypeClass));
        if (!typeObj) return nullptr;

        void* args[1] = { typeObj };
        void* exc = nullptr;
        Il2CppObject* res = il2cpp_runtime_invoke(methodComponentGetComp, componentOrObj, args, &exc);
        if (!exc && res && IsValidUnityObj(res)) return (void*)res;
        return nullptr;
    }

    void* GetComponentTransform(void* component) {
        if (!IsValidUnityObj(component)) return nullptr;
        EnsureThreadAttached();
        if (methodComponentGetTrans && il2cpp_runtime_invoke) {
            void* exc = nullptr;
            Il2CppObject* res = il2cpp_runtime_invoke(methodComponentGetTrans, component, nullptr, &exc);
            if (!exc && res && IsValidUnityObj(res)) return (void*)res;
        }
        return nullptr;
    }

    void* GetGameObject(void* component) {
        if (!IsValidUnityObj(component)) return nullptr;
        EnsureThreadAttached();
        if (methodComponentGetGameObject && il2cpp_runtime_invoke) {
            void* exc = nullptr;
            Il2CppObject* res = il2cpp_runtime_invoke(methodComponentGetGameObject, component, nullptr, &exc);
            if (!exc && res && IsValidUnityObj(res)) return (void*)res;
        }
        return nullptr;
    }

    bool IsGameObjectActiveInHierarchy(void* componentOrGameObject) {
        if (!IsValidUnityObj(componentOrGameObject)) return false;
        EnsureThreadAttached();
        void* go = methodComponentGetGameObject ? GetGameObject(componentOrGameObject) : componentOrGameObject;
        if (!go || !IsValidUnityObj(go)) go = componentOrGameObject;

        if (methodGameObjectGetActiveInH && il2cpp_runtime_invoke) {
            void* exc = nullptr;
            Il2CppObject* res = il2cpp_runtime_invoke(methodGameObjectGetActiveInH, go, nullptr, &exc);
            if (!exc && res && IsValidMemPtr(res, 0x18)) {
                return *(bool*)((char*)res + 0x10);
            }
        }
        return true;
    }

    bool GetTransformPosition(void* transform, Vector3* outPos) {
        if (!IsValidUnityObj(transform) || !outPos) return false;
        EnsureThreadAttached();
        if (methodTransformGetPos && il2cpp_runtime_invoke) {
            void* exc = nullptr;
            Il2CppObject* res = il2cpp_runtime_invoke(methodTransformGetPos, transform, nullptr, &exc);
            if (!exc && res && IsValidMemPtr(res, 0x20)) {
                *outPos = *(Vector3*)((char*)res + 0x10);
                return true;
            }
        }
        return false;
    }

    bool GetRigidbodyPosition(void* rb, Vector3* outPos) {
        if (!IsValidUnityObj(rb) || !outPos) return false;
        void* tr = GetComponentTransform(rb);
        if (tr && IsValidUnityObj(tr)) {
            return GetTransformPosition(tr, outPos);
        }
        return false;
    }

    bool WorldToScreen(void* camera, Vector3 worldPos, Vector3* outScreen) {
        if (!IsValidUnityObj(camera) || !outScreen) return false;
        EnsureThreadAttached();
        if (methodWorldToScreen && il2cpp_runtime_invoke) {
            void* args[1] = { &worldPos };
            void* exc = nullptr;
            Il2CppObject* res = il2cpp_runtime_invoke(methodWorldToScreen, camera, args, &exc);
            if (!exc && res && IsValidMemPtr(res, 0x20)) {
                *outScreen = *(Vector3*)((char*)res + 0x10);
                return true;
            }
        }
        return false;
    }

    bool IsLocalPlayer(void* networkBehaviourObj) {
        if (!IsValidUnityObj(networkBehaviourObj)) return false;

        // Try cached method or resolve dynamically from object class
        const MethodInfo* mOwner = methodGetIsOwner;
        if (!mOwner && il2cpp_object_get_class) {
            Il2CppClass* klass = (Il2CppClass*)il2cpp_object_get_class((Il2CppObject*)networkBehaviourObj);
            if (klass) mOwner = FindMethod(klass, "get_IsOwner", 0);
        }

        if (mOwner && il2cpp_runtime_invoke) {
            EnsureThreadAttached();
            void* exc = nullptr;
            Il2CppObject* res = il2cpp_runtime_invoke(mOwner, networkBehaviourObj, nullptr, &exc);
            if (!exc && res && IsValidMemPtr(res, 0x18)) {
                return *(bool*)((char*)res + 0x10);
            }
        }
        return false;
    }

    bool IsSpawned(void* networkBehaviourObj) {
        if (!IsValidUnityObj(networkBehaviourObj)) return true;

        const MethodInfo* mSpawned = methodGetIsSpawned;
        if (!mSpawned && il2cpp_object_get_class) {
            Il2CppClass* klass = (Il2CppClass*)il2cpp_object_get_class((Il2CppObject*)networkBehaviourObj);
            if (klass) mSpawned = FindMethod(klass, "get_IsSpawned", 0);
        }

        if (mSpawned && il2cpp_runtime_invoke) {
            EnsureThreadAttached();
            void* exc = nullptr;
            Il2CppObject* res = il2cpp_runtime_invoke(mSpawned, networkBehaviourObj, nullptr, &exc);
            if (!exc && res && IsValidMemPtr(res, 0x18)) {
                return *(bool*)((char*)res + 0x10);
            }
        }
        return true;
    }

    bool SetGameObjectActive(void* go, bool active) {
        if (!IsValidUnityObj(go) || !methodGameObjectSetActive || !il2cpp_runtime_invoke) return false;
        EnsureThreadAttached();
        void* args[1] = { &active };
        void* exc = nullptr;
        il2cpp_runtime_invoke(methodGameObjectSetActive, go, args, &exc);
        return exc == nullptr;
    }

    bool SetTransformPosition(void* transform, Vector3 pos) {
        if (!IsValidUnityObj(transform) || !methodTransformSetPos || !il2cpp_runtime_invoke) return false;
        EnsureThreadAttached();
        void* args[1] = { &pos };
        void* exc = nullptr;
        il2cpp_runtime_invoke(methodTransformSetPos, transform, args, &exc);
        return exc == nullptr;
    }

    bool GetTransformForward(void* transform, Vector3* outForward) {
        if (!IsValidUnityObj(transform) || !outForward || !methodTransformGetForward || !il2cpp_runtime_invoke) return false;
        EnsureThreadAttached();
        void* exc = nullptr;
        Il2CppObject* res = il2cpp_runtime_invoke(methodTransformGetForward, transform, nullptr, &exc);
        if (!exc && res && IsValidMemPtr(res, 0x20)) {
            *outForward = *(Vector3*)((char*)res + 0x10);
            return true;
        }
        return false;
    }

    bool TransformLookAt(void* transform, Vector3 target) {
        if (!IsValidUnityObj(transform) || !methodTransformLookAt || !il2cpp_runtime_invoke) return false;
        EnsureThreadAttached();
        void* args[1] = { &target };
        void* exc = nullptr;
        il2cpp_runtime_invoke(methodTransformLookAt, transform, args, &exc);
        return exc == nullptr;
    }

    bool SetRigidbodyLinearVelocity(void* rb, Vector3 vel) {
        if (!IsValidUnityObj(rb) || !methodRbSetLinearVelocity || !il2cpp_runtime_invoke) return false;
        EnsureThreadAttached();
        void* args[1] = { &vel };
        void* exc = nullptr;
        il2cpp_runtime_invoke(methodRbSetLinearVelocity, rb, args, &exc);
        return exc == nullptr;
    }

    bool SetRigidbodyAngularVelocity(void* rb, Vector3 vel) {
        if (!IsValidUnityObj(rb) || !methodRbSetAngularVelocity || !il2cpp_runtime_invoke) return false;
        EnsureThreadAttached();
        void* args[1] = { &vel };
        void* exc = nullptr;
        il2cpp_runtime_invoke(methodRbSetAngularVelocity, rb, args, &exc);
        return exc == nullptr;
    }

    bool MoveRigidbodyPosition(void* rb, Vector3 pos) {
        if (!IsValidUnityObj(rb) || !methodRbMovePosition || !il2cpp_runtime_invoke) return false;
        EnsureThreadAttached();
        void* args[1] = { &pos };
        void* exc = nullptr;
        il2cpp_runtime_invoke(methodRbMovePosition, rb, args, &exc);
        return exc == nullptr;
    }

    void SetCursorState(bool unlocked) {
        EnsureThreadAttached();
        if (unlocked) {
            if (methodSetCursorLockState && il2cpp_runtime_invoke) {
                int mode = 0; // CursorLockMode.None
                void* args[1] = { &mode };
                void* exc = nullptr;
                il2cpp_runtime_invoke(methodSetCursorLockState, nullptr, args, &exc);
            }
            if (methodSetCursorVisible && il2cpp_runtime_invoke) {
                bool vis = true;
                void* args[1] = { &vis };
                void* exc = nullptr;
                il2cpp_runtime_invoke(methodSetCursorVisible, nullptr, args, &exc);
            }
        } else {
            if (methodSetCursorLockState && il2cpp_runtime_invoke) {
                int mode = 1; // CursorLockMode.Locked
                void* args[1] = { &mode };
                void* exc = nullptr;
                il2cpp_runtime_invoke(methodSetCursorLockState, nullptr, args, &exc);
            }
            if (methodSetCursorVisible && il2cpp_runtime_invoke) {
                bool vis = false;
                void* args[1] = { &vis };
                void* exc = nullptr;
                il2cpp_runtime_invoke(methodSetCursorVisible, nullptr, args, &exc);
            }
        }
    }

    void* GetBootstrapInstance() {
        EnsureThreadAttached();
        if (methodBootstrapGetInstance && il2cpp_runtime_invoke) {
            void* exc = nullptr;
            Il2CppObject* res = il2cpp_runtime_invoke(methodBootstrapGetInstance, nullptr, nullptr, &exc);
            if (!exc && res && IsValidUnityObj(res)) return (void*)res;
        }
        return nullptr;
    }

    uint64_t GetCurrentLobbyID() {
        void* bs = GetBootstrapInstance();
        if (!bs || !IsValidUnityObj(bs)) return 0;
        return *(uint64_t*)((char*)bs + 0x38);
    }

    bool HostLobby(bool privateLobby) {
        void* bs = GetBootstrapInstance();
        if (!bs || !IsValidUnityObj(bs) || !methodBootstrapHostLobby || !il2cpp_runtime_invoke) return false;
        EnsureThreadAttached();
        void* args[1] = { &privateLobby };
        void* exc = nullptr;
        il2cpp_runtime_invoke(methodBootstrapHostLobby, bs, args, &exc);
        return exc == nullptr;
    }

    bool LeaveLobby() {
        void* bs = GetBootstrapInstance();
        if (!bs || !IsValidUnityObj(bs) || !methodBootstrapLeaveLobby || !il2cpp_runtime_invoke) return false;
        EnsureThreadAttached();
        void* exc = nullptr;
        il2cpp_runtime_invoke(methodBootstrapLeaveLobby, bs, nullptr, &exc);
        return exc == nullptr;
    }
};
