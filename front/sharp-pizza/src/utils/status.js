export const getStatus = (date1, date2) => {
  const differenceInMinutes = Math.abs(date2 - date1) / (1000 * 60) - 180;
  if (differenceInMinutes < 15) {
    return 'en preparacion'
  } else if (differenceInMinutes < 30) {
    return 'en delivery'
  } else {
    return 'entregado'
  }
};