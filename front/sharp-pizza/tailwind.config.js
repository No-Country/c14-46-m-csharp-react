/** @type {import('tailwindcss').Config} */
export default {
  content: ['./index.html', './src/**/*.{js,ts,jsx,tsx}'],
  theme: {
    screens: {
      // Small devices such as mobile phones
      sm: '480px',
      // => @media (min-width: 640px) { ... }

      // Larger devices like tablets
      md: '768px',
      // => @media (min-width: 768px) { ... }

      // Medium size laptops and screens
      lg: '1024px',
      // => @media (min-width: 1024px) { ... }

      // Pantallas más grandes como las de escritorio
      xl: '1280px',
      // => @media (min-width: 1280px) { ... }

      // Extra large screens or high resolution screens
      '2xl': '1536px',
      // => @media (min-width: 1536px) { ... }
    },
    extend: {},
  },
  plugins: [require('daisyui')],
 
};
