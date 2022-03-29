import { FilterDeviceByNamePipe } from './filter-device-by-name.pipe';

describe('FilterDeviceByNamePipe', () => {
  it('create an instance', () => {
    const pipe = new FilterDeviceByNamePipe();
    expect(pipe).toBeTruthy();
  });
});
