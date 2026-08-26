#pragma once
#include <windows.h>
#include <string>
#include <cstring>
#include <vector>
#include <algorithm>

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

    // Cached Unity / FishNet class & method pointers
    Il2CppClass* classObject           = nullptr;
    Il2CppClass* classGameObject       = nullptr;
    Il2CppClass* classCamera           = nullptr;
    Il2CppClass* classTransform        = nullptr;
    Il2CppClass* classComponent        = nullptr;
    Il2CppClass* classRigidbody        = nullptr;
    Il2CppClass* classNetworkBehaviour = nullptr;

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
        if (exc || !res) return nullptr;
        return (Il2CppArray*)res;
    }

    void* GetMainCamera() {
        EnsureThreadAttached();
        // 1. Try Camera.main
        if (methodCameraGetMain && il2cpp_runtime_invoke) {
            void* exc = nullptr;
            Il2CppObject* res = il2cpp_runtime_invoke(methodCameraGetMain, nullptr, nullptr, &exc);
            if (!exc && res) return (void*)res;
        }

        // 2. Try Camera.current
        if (methodCameraGetCurrent && il2cpp_runtime_invoke) {
            void* exc = nullptr;
            Il2CppObject* res = il2cpp_runtime_invoke(methodCameraGetCurrent, nullptr, nullptr, &exc);
            if (!exc && res) return (void*)res;
        }

        // 3. Try Camera.allCameras
        if (methodCameraGetAll && il2cpp_runtime_invoke) {
            void* exc = nullptr;
            Il2CppArray* arr = (Il2CppArray*)il2cpp_runtime_invoke(methodCameraGetAll, nullptr, nullptr, &exc);
            if (!exc && arr) {
                uintptr_t cnt = *(uintptr_t*)((char*)arr + 0x18);
                void** items = (void**)((char*)arr + 0x20);
                for (uintptr_t i = 0; i < cnt; i++) {
                    if (items[i]) return items[i];
                }
            }
        }
        return nullptr;
    }

    void* GetComponent(void* componentOrObj, Il2CppClass* targetTypeClass) {
        EnsureThreadAttached();
        if (!componentOrObj || !targetTypeClass || !methodComponentGetComp || !il2cpp_runtime_invoke)
            return nullptr;

        void* typeObj = il2cpp_type_get_object(il2cpp_class_get_type(targetTypeClass));
        if (!typeObj) return nullptr;

        void* args[1] = { typeObj };
        void* exc = nullptr;
        Il2CppObject* res = il2cpp_runtime_invoke(methodComponentGetComp, componentOrObj, args, &exc);
        if (!exc && res) return (void*)res;
        return nullptr;
    }

    void* GetComponentTransform(void* component) {
        if (!component) return nullptr;
        EnsureThreadAttached();
        if (methodComponentGetTrans && il2cpp_runtime_invoke) {
            void* exc = nullptr;
            Il2CppObject* res = il2cpp_runtime_invoke(methodComponentGetTrans, component, nullptr, &exc);
            if (!exc && res) return (void*)res;
        }
        return nullptr;
    }

    void* GetGameObject(void* component) {
        if (!component) return nullptr;
        EnsureThreadAttached();
        if (methodComponentGetGameObject && il2cpp_runtime_invoke) {
            void* exc = nullptr;
            Il2CppObject* res = il2cpp_runtime_invoke(methodComponentGetGameObject, component, nullptr, &exc);
            if (!exc && res) return (void*)res;
        }
        return nullptr;
    }

    bool IsGameObjectActiveInHierarchy(void* componentOrGameObject) {
        if (!componentOrGameObject) return false;
        EnsureThreadAttached();
        void* go = methodComponentGetGameObject ? GetGameObject(componentOrGameObject) : componentOrGameObject;
        if (!go) go = componentOrGameObject;

        if (methodGameObjectGetActiveInH && il2cpp_runtime_invoke) {
            void* exc = nullptr;
            Il2CppObject* res = il2cpp_runtime_invoke(methodGameObjectGetActiveInH, go, nullptr, &exc);
            if (!exc && res) {
                return *(bool*)((char*)res + 0x10);
            }
        }
        return true;
    }

    bool GetTransformPosition(void* transform, Vector3* outPos) {
        if (!transform || !outPos) return false;
        EnsureThreadAttached();
        if (methodTransformGetPos && il2cpp_runtime_invoke) {
            void* exc = nullptr;
            Il2CppObject* res = il2cpp_runtime_invoke(methodTransformGetPos, transform, nullptr, &exc);
            if (!exc && res) {
                *outPos = *(Vector3*)((char*)res + 0x10);
                return true;
            }
        }
        return false;
    }

    bool GetRigidbodyPosition(void* rb, Vector3* outPos) {
        if (!rb || !outPos) return false;
        void* tr = GetComponentTransform(rb);
        if (tr) {
            return GetTransformPosition(tr, outPos);
        }
        return false;
    }

    bool WorldToScreen(void* camera, Vector3 worldPos, Vector3* outScreen) {
        if (!camera || !outScreen) return false;
        EnsureThreadAttached();
        if (methodWorldToScreen && il2cpp_runtime_invoke) {
            void* args[1] = { &worldPos };
            void* exc = nullptr;
            Il2CppObject* res = il2cpp_runtime_invoke(methodWorldToScreen, camera, args, &exc);
            if (!exc && res) {
                *outScreen = *(Vector3*)((char*)res + 0x10);
                return true;
            }
        }
        return false;
    }

    bool IsLocalPlayer(void* networkBehaviourObj) {
        if (!networkBehaviourObj || !methodGetIsOwner || !il2cpp_runtime_invoke)
            return false;

        EnsureThreadAttached();
        void* exc = nullptr;
        Il2CppObject* res = il2cpp_runtime_invoke(methodGetIsOwner, networkBehaviourObj, nullptr, &exc);
        if (!exc && res) {
            return *(bool*)((char*)res + 0x10);
        }
        return false;
    }

    bool IsSpawned(void* networkBehaviourObj) {
        if (!networkBehaviourObj || !methodGetIsSpawned || !il2cpp_runtime_invoke)
            return true; // Default true if method missing

        EnsureThreadAttached();
        void* exc = nullptr;
        Il2CppObject* res = il2cpp_runtime_invoke(methodGetIsSpawned, networkBehaviourObj, nullptr, &exc);
        if (!exc && res) {
            return *(bool*)((char*)res + 0x10);
        }
        return true;
    }

    bool SetGameObjectActive(void* go, bool active) {
        if (!go || !methodGameObjectSetActive || !il2cpp_runtime_invoke) return false;
        EnsureThreadAttached();
        void* args[1] = { &active };
        void* exc = nullptr;
        il2cpp_runtime_invoke(methodGameObjectSetActive, go, args, &exc);
        return exc == nullptr;
    }

    bool SetTransformPosition(void* transform, Vector3 pos) {
        if (!transform || !methodTransformSetPos || !il2cpp_runtime_invoke) return false;
        EnsureThreadAttached();
        void* args[1] = { &pos };
        void* exc = nullptr;
        il2cpp_runtime_invoke(methodTransformSetPos, transform, args, &exc);
        return exc == nullptr;
    }

    bool GetTransformForward(void* transform, Vector3* outForward) {
        if (!transform || !outForward || !methodTransformGetForward || !il2cpp_runtime_invoke) return false;
        EnsureThreadAttached();
        void* exc = nullptr;
        Il2CppObject* res = il2cpp_runtime_invoke(methodTransformGetForward, transform, nullptr, &exc);
        if (!exc && res) {
            *outForward = *(Vector3*)((char*)res + 0x10);
            return true;
        }
        return false;
    }

    bool TransformLookAt(void* transform, Vector3 target) {
        if (!transform || !methodTransformLookAt || !il2cpp_runtime_invoke) return false;
        EnsureThreadAttached();
        void* args[1] = { &target };
        void* exc = nullptr;
        il2cpp_runtime_invoke(methodTransformLookAt, transform, args, &exc);
        return exc == nullptr;
    }

    bool SetRigidbodyLinearVelocity(void* rb, Vector3 vel) {
        if (!rb || !methodRbSetLinearVelocity || !il2cpp_runtime_invoke) return false;
        EnsureThreadAttached();
        void* args[1] = { &vel };
        void* exc = nullptr;
        il2cpp_runtime_invoke(methodRbSetLinearVelocity, rb, args, &exc);
        return exc == nullptr;
    }

    bool SetRigidbodyAngularVelocity(void* rb, Vector3 vel) {
        if (!rb || !methodRbSetAngularVelocity || !il2cpp_runtime_invoke) return false;
        EnsureThreadAttached();
        void* args[1] = { &vel };
        void* exc = nullptr;
        il2cpp_runtime_invoke(methodRbSetAngularVelocity, rb, args, &exc);
        return exc == nullptr;
    }

    bool MoveRigidbodyPosition(void* rb, Vector3 pos) {
        if (!rb || !methodRbMovePosition || !il2cpp_runtime_invoke) return false;
        EnsureThreadAttached();
        void* args[1] = { &pos };
        void* exc = nullptr;
        il2cpp_runtime_invoke(methodRbMovePosition, rb, args, &exc);
        return exc == nullptr;
    }
};
