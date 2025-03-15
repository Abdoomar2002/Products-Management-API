/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,ts}"],
  theme: {
    extend: {
      colors: {
        primary: {
          DEFAULT: '#3B82F6',
          dark: '#2563EB',
        },
        secondary: {
          DEFAULT: '#64748B',
          dark: '#475569',
        },
        danger: {
          DEFAULT: '#EF4444',
          dark: '#DC2626',
        }
      }
    }
  },
  plugins: [],
};

