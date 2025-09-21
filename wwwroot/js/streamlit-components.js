// Streamlit-like Components JavaScript

// Initialize all components when document is ready
document.addEventListener('DOMContentLoaded', function() {
    initializeSliders();
    initializeFormValidation();
    initializeTooltips();
    initializeAnimations();
});

// Initialize slider components with real-time updates
function initializeSliders() {
    const sliders = document.querySelectorAll('input[type="range"]');
    
    sliders.forEach(slider => {
        // Create or find the value display element
        let valueDisplay = document.querySelector(`#${slider.id}Value`);
        if (!valueDisplay) {
            // Look for span in the label
            const label = document.querySelector(`label[for="${slider.id}"]`);
            if (label) {
                valueDisplay = label.querySelector('span');
            }
        }
        
        if (valueDisplay) {
            // Update display on input
            slider.addEventListener('input', function() {
                valueDisplay.textContent = this.value;
                
                // Trigger custom event for other listeners
                this.dispatchEvent(new CustomEvent('sliderChange', {
                    detail: { value: this.value, id: this.id }
                }));
            });
            
            // Set initial value
            valueDisplay.textContent = slider.value;
        }
    });
}

// Form validation for Streamlit-like components
function initializeFormValidation() {
    const forms = document.querySelectorAll('form');
    
    forms.forEach(form => {
        form.addEventListener('submit', function(e) {
            if (!validateForm(this)) {
                e.preventDefault();
                showValidationErrors(this);
            }
        });
        
        // Real-time validation
        const inputs = form.querySelectorAll('input, select, textarea');
        inputs.forEach(input => {
            input.addEventListener('blur', function() {
                validateField(this);
            });
        });
    });
}

// Validate individual form field
function validateField(field) {
    const value = field.value.trim();
    let isValid = true;
    let errorMessage = '';
    
    // Required field validation
    if (field.hasAttribute('required') && !value) {
        isValid = false;
        errorMessage = 'This field is required';
    }
    
    // Email validation
    if (field.type === 'email' && value && !isValidEmail(value)) {
        isValid = false;
        errorMessage = 'Please enter a valid email address';
    }
    
    // Number validation
    if (field.type === 'number' && value) {
        const min = field.getAttribute('min');
        const max = field.getAttribute('max');
        const numValue = parseFloat(value);
        
        if (min && numValue < parseFloat(min)) {
            isValid = false;
            errorMessage = `Value must be at least ${min}`;
        }
        
        if (max && numValue > parseFloat(max)) {
            isValid = false;
            errorMessage = `Value must be no more than ${max}`;
        }
    }
    
    // Update field styling
    if (isValid) {
        field.classList.remove('is-invalid');
        field.classList.add('is-valid');
        removeErrorMessage(field);
    } else {
        field.classList.remove('is-valid');
        field.classList.add('is-invalid');
        showErrorMessage(field, errorMessage);
    }
    
    return isValid;
}

// Validate entire form
function validateForm(form) {
    const fields = form.querySelectorAll('input[required], select[required], textarea[required]');
    let isValid = true;
    
    fields.forEach(field => {
        if (!validateField(field)) {
            isValid = false;
        }
    });
    
    return isValid;
}

// Show validation errors
function showValidationErrors(form) {
    const firstInvalidField = form.querySelector('.is-invalid');
    if (firstInvalidField) {
        firstInvalidField.focus();
        
        // Show toast notification
        showToast('Please correct the highlighted errors', 'error');
    }
}

// Show error message for field
function showErrorMessage(field, message) {
    removeErrorMessage(field);
    
    const errorDiv = document.createElement('div');
    errorDiv.className = 'invalid-feedback';
    errorDiv.textContent = message;
    errorDiv.setAttribute('data-field-error', field.id || field.name);
    
    field.parentNode.appendChild(errorDiv);
}

// Remove error message for field
function removeErrorMessage(field) {
    const existingError = field.parentNode.querySelector(`[data-field-error="${field.id || field.name}"]`);
    if (existingError) {
        existingError.remove();
    }
}

// Email validation helper
function isValidEmail(email) {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
}

// Initialize tooltips for help text
function initializeTooltips() {
    const helpElements = document.querySelectorAll('.metric-help, [data-bs-toggle="tooltip"]');
    
    helpElements.forEach(element => {
        if (element.hasAttribute('title') || element.hasAttribute('data-bs-title')) {
            // Initialize Bootstrap tooltip if available
            if (typeof bootstrap !== 'undefined' && bootstrap.Tooltip) {
                new bootstrap.Tooltip(element);
            }
        }
    });
}

// Initialize animations and transitions
function initializeAnimations() {
    // Fade in animation for metric cards
    const metricCards = document.querySelectorAll('.metric-card');
    metricCards.forEach((card, index) => {
        card.style.opacity = '0';
        card.style.transform = 'translateY(20px)';
        
        setTimeout(() => {
            card.style.transition = 'opacity 0.5s ease, transform 0.5s ease';
            card.style.opacity = '1';
            card.style.transform = 'translateY(0)';
        }, index * 100);
    });
    
    // Smooth scrolling for anchor links
    const anchorLinks = document.querySelectorAll('a[href^="#"]');
    anchorLinks.forEach(link => {
        link.addEventListener('click', function(e) {
            e.preventDefault();
            const target = document.querySelector(this.getAttribute('href'));
            if (target) {
                target.scrollIntoView({ behavior: 'smooth' });
            }
        });
    });
}

// Show toast notification
function showToast(message, type = 'info') {
    // Create toast element
    const toast = document.createElement('div');
    toast.className = `toast align-items-center text-white bg-${type === 'error' ? 'danger' : type} border-0`;
    toast.setAttribute('role', 'alert');
    toast.innerHTML = `
        <div class="d-flex">
            <div class="toast-body">
                ${message}
            </div>
            <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast"></button>
        </div>
    `;
    
    // Add to toast container or create one
    let toastContainer = document.querySelector('.toast-container');
    if (!toastContainer) {
        toastContainer = document.createElement('div');
        toastContainer.className = 'toast-container position-fixed top-0 end-0 p-3';
        document.body.appendChild(toastContainer);
    }
    
    toastContainer.appendChild(toast);
    
    // Initialize and show toast
    if (typeof bootstrap !== 'undefined' && bootstrap.Toast) {
        const bsToast = new bootstrap.Toast(toast);
        bsToast.show();
        
        // Remove toast element after it's hidden
        toast.addEventListener('hidden.bs.toast', () => {
            toast.remove();
        });
    } else {
        // Fallback without Bootstrap
        toast.style.display = 'block';
        setTimeout(() => {
            toast.style.opacity = '0';
            setTimeout(() => toast.remove(), 300);
        }, 3000);
    }
}

// Utility functions for Streamlit-like behavior
const StreamlitUtils = {
    // Update metric value with animation
    updateMetric: function(metricId, newValue, delta = null, deltaColor = 'normal') {
        const metricCard = document.querySelector(`#${metricId}`);
        if (!metricCard) return;
        
        const valueElement = metricCard.querySelector('.metric-value');
        const deltaElement = metricCard.querySelector('.metric-delta');
        
        if (valueElement) {
            // Animate value change
            valueElement.style.transform = 'scale(1.1)';
            setTimeout(() => {
                valueElement.textContent = newValue;
                valueElement.style.transform = 'scale(1)';
            }, 150);
        }
        
        if (deltaElement && delta !== null) {
            deltaElement.className = `metric-delta delta-${deltaColor}`;
            deltaElement.innerHTML = `<span class="${deltaColor}">${delta}</span>`;
        }
    },
    
    // Show loading state for elements
    showLoading: function(element, show = true) {
        if (show) {
            element.style.opacity = '0.6';
            element.style.pointerEvents = 'none';
            
            // Add spinner if not exists
            if (!element.querySelector('.spinner-border')) {
                const spinner = document.createElement('div');
                spinner.className = 'spinner-border spinner-border-sm ms-2';
                spinner.setAttribute('role', 'status');
                element.appendChild(spinner);
            }
        } else {
            element.style.opacity = '1';
            element.style.pointerEvents = 'auto';
            
            // Remove spinner
            const spinner = element.querySelector('.spinner-border');
            if (spinner) {
                spinner.remove();
            }
        }
    },
    
    // Format numbers for display
    formatNumber: function(num, decimals = 1) {
        if (num >= 1000000) {
            return (num / 1000000).toFixed(decimals) + 'M';
        } else if (num >= 1000) {
            return (num / 1000).toFixed(decimals) + 'K';
        } else {
            return num.toFixed(decimals);
        }
    }
};

// Make utilities available globally
window.StreamlitUtils = StreamlitUtils;