using Microsoft.AspNetCore.Components;

namespace StreamlitLikeApp.Services
{
    public class StreamlitService
    {
        public ComponentState State { get; } = new ComponentState();
        
        // Streamlit-like methods for state management
        public T GetState<T>(string key, T defaultValue = default!)
        {
            return State.Get(key, defaultValue);
        }
        
        public void SetState<T>(string key, T value)
        {
            State.Set(key, value);
        }
        
        public void ClearState()
        {
            State.Clear();
        }
    }
    
    public class ComponentState
    {
        private readonly Dictionary<string, object> _state = new();
        
        public T Get<T>(string key, T defaultValue = default!)
        {
            if (_state.TryGetValue(key, out var value) && value is T typedValue)
            {
                return typedValue;
            }
            return defaultValue;
        }
        
        public void Set<T>(string key, T value)
        {
            if (value != null)
            {
                _state[key] = value;
            }
        }
        
        public void Clear()
        {
            _state.Clear();
        }
        
        public bool ContainsKey(string key)
        {
            return _state.ContainsKey(key);
        }
        
        public void Remove(string key)
        {
            _state.Remove(key);
        }
    }
}