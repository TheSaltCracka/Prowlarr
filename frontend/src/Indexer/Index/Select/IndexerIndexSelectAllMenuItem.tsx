import React, { useCallback } from 'react';
import { SelectActionType, useSelect } from 'App/SelectContext';
import PageToolbarOverflowMenuItem from 'Components/Page/Toolbar/PageToolbarOverflowMenuItem';
import { icons } from 'Helpers/Props';
import translate from 'Utilities/String/translate';

interface IndexerIndexSelectAllMenuItemProps {
  label: string;
  isSelectMode: boolean;
}

function IndexerIndexSelectAllMenuItem(
  props: IndexerIndexSelectAllMenuItemProps
) {
  const { isSelectMode } = props;
  const [selectState, selectDispatch] = useSelect();
  const { allSelected, allUnselected } = selectState;

  let iconName = icons.SQUARE_MINUS;

  if (allSelected) {
    iconName = icons.CHECK_SQUARE;
  } else if (allUnselected) {
    iconName = icons.SQUARE;
  }

  const onPressWrapper = useCallback(() => {
    selectDispatch({
      type: allSelected
        ? SelectActionType.UnselectAll
        : SelectActionType.SelectAll,
    });
  }, [allSelected, selectDispatch]);

  return isSelectMode ? (
    <PageToolbarOverflowMenuItem
      label={allSelected ? translate('UnselectAll') : translate('SelectAll')}
      iconName={iconName}
      onPress={onPressWrapper}
    />
  ) : null;
}

export default IndexerIndexSelectAllMenuItem;
